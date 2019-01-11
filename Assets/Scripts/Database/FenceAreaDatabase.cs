using System.Collections.Generic;
using UnityEngine;

public class FenceAreaDatabase : BaseDatabase
{
    public List<FenceAreaData> FenceAreaList { get; protected set; } = new List<FenceAreaData>();
    protected int UniqueId = 0;

    public override void ClearData()
    {
        FenceAreaList.Clear();
        UniqueId = 0;
    }

    public override void LoadDataFromDefault(DefaultLocalData data)
    {
        
    }

    public override void LoadDataFromJson(string json)
    {
        FenceAreaList = JsonUtility.FromJson<Serialization<FenceAreaData>>(json).ToList();
        foreach (var data in FenceAreaList)
        {
            if (data.Uid > UniqueId)
            {
                UniqueId = data.Uid;
            }
        }
    }

    public override string SaveDataAsJson()
    {
        return JsonUtility.ToJson(new Serialization<FenceAreaData>(FenceAreaList));
    }

    public FenceAreaData GetFenceAreaData(int uid)
    {
        foreach (var data in FenceAreaList)
        {
            if (data.Uid == uid)
            {
                return data;
            }
        }
        return null;
    }

    public void AddFenceArea(FenceAreaData data)
    {
        IsDirty = true;
        data.Uid = ++UniqueId;
        FenceAreaList.Add(data);
    }

    public void RemoveFenceArea(int uid)
    {
        IsDirty = true;
        foreach (var data in FenceAreaList)
        {
            if (data.Uid == uid)
            {
                FenceAreaList.Remove(data);
                break;
            }
        }
    }
}