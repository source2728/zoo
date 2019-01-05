using System.Collections.Generic;
using UnityEngine;

public class ZooDatabase : BaseDatabase
{
    public ZooData ZooData { get; set; }

    public override void ClearData()
    {
        ZooData = new ZooData();
    }

    public override void LoadDataFromJson(string json)
    {
        ZooData = JsonUtility.FromJson<ZooData>(json);
    }

    public override void LoadDataFromDefault(DefaultLocalData data)
    {
        ZooData.Fill(data.ZooData);
    }

    public override string SaveDataAsJson()
    {
        return JsonUtility.ToJson(ZooData);
    }

    public void Rename(string newName)
    {
        IsDirty = true;
        ZooData.Name = newName;
    }

    public void SetPrice(int newPrice)
    {
        IsDirty = true;
        ZooData.Price = newPrice;
    }
}