using GameFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public partial class DatabaseComponent : GameFrameworkComponent
{
    protected Dictionary<string, BaseDatabase> LocalDatabases = new Dictionary<string, BaseDatabase>();
    protected bool m_IsDataDirty = false;
    static long NextSaveTime = 0;

    public DefaultLocalData DefaultLocalData;

    public void SaveGame()
    {
        foreach (var database in LocalDatabases)
        {
            if (database.Value.IsDirty)
            {
                var strJson = database.Value.SaveDataAsJson();
                Debug.Log(database.Key + " Save Json:" + strJson);
                PlayerPrefs.SetString(database.Key, strJson);
                database.Value.IsDirty = false;
            }
        }
    }

    public void LoadGame()
    {
        foreach (var database in LocalDatabases)
        {
            database.Value.ClearData();
            var strJson = PlayerPrefs.GetString(database.Key);
            if (strJson != null && strJson != "")
            {
                database.Value.LoadDataFromJson(strJson);
                Debug.Log(database.Key + " Load Json:" + strJson);
            }
            else
            {
                Debug.Log(database.Key + " Load Empty Json");
            }
        }
    }

    public void ResetGame()
    {
        foreach (var database in LocalDatabases)
        {
            database.Value.ClearData();
            database.Value.LoadDataFromDefault(DefaultLocalData);
            database.Value.IsDirty = true;
        }
        DataUpdated();
    }

    public void DataUpdated()
    {
        m_IsDataDirty = true;
    }

    public T AddDatabase<T>() where T : BaseDatabase, new()
    {
        Type type = typeof(T);
        var database = new T();
        LocalDatabases.Add(type.Name, database);
        return database;
    }

    private void Update()
    {
        if (m_IsDataDirty)
        {
            m_IsDataDirty = false;
            GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtDataUpdated>());
            NextSaveTime = TimeUtil.ConvertDateTimeToLong(System.DateTime.Now);
        }

        if (NextSaveTime > 0)
        {
            var curTime = TimeUtil.ConvertDateTimeToLong(System.DateTime.Now);
            if (curTime - NextSaveTime >= 1)
            {
                NextSaveTime = 0;
                SaveGame();
            }
        }
    }
}
