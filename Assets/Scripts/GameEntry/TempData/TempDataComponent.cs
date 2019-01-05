using GameFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public partial class TempDataComponent : GameFrameworkComponent
{
    protected Dictionary<string, BaseTempData> LocalDatabases = new Dictionary<string, BaseTempData>();

    public T AddTempData<T>() where T : BaseTempData, new()
    {
        Type type = typeof(T);
        var database = new T();
        LocalDatabases.Add(type.Name, database);
        return database;
    }
}
