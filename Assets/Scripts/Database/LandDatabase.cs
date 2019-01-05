using System.Collections.Generic;
using UnityEngine;

public class LandDatabase : BaseDatabase
{
    public List<LandData> LandList { get; private set; } = new List<LandData>();
    public int UniqueId = 0;

    public override void ClearData()
    {
        LandList.Clear();
        UniqueId = 0;
    }

    public override void LoadDataFromJson(string json)
    {
        LandList = JsonUtility.FromJson<Serialization<LandData>>(json).ToList();
        foreach (var facility in LandList)
        {
            if (facility.Uid > UniqueId)
            {
                UniqueId = facility.Uid;
            }
        }
    }

    public override void LoadDataFromDefault(DefaultLocalData data)
    {
    }

    public override string SaveDataAsJson()
    {
        return JsonUtility.ToJson(new Serialization<LandData>(LandList));
    }

    public void AddLand(LandData data)
    {
        IsDirty = true;
        data.Uid = ++UniqueId;
        LandList.Add(data);
    }

    public void RemoveLand(int uid)
    {
        IsDirty = true;
        foreach (var land in LandList)
        {
            if (land.Uid == uid)
            {
                LandList.Remove(land);
                break;
            }
        }
    }

    public void UpdateLand(int uid, Vector2Int postion, float rotation)
    {
        IsDirty = true;
        foreach (var land in LandList)
        {
            if (land.Uid == uid)
            {
                land.LeftBottom.x = postion.x;
                land.LeftBottom.y = postion.y;
                land.Rotation = rotation;
                break;
            }
        }
    }
}