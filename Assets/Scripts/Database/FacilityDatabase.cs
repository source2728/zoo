using System.Collections.Generic;
using UnityEngine;

public class FacilityDatabase : BaseDatabase
{
    public List<FacilityData> FacilityList { get; private set; } = new List<FacilityData>();
    public int UniqueId = 0;

    public override void ClearData()
    {
        FacilityList.Clear();
        UniqueId = 0;
    }

    public override void LoadDataFromJson(string json)
    {
        FacilityList = JsonUtility.FromJson<Serialization<FacilityData>>(json).ToList();
        foreach (var facility in FacilityList)
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
        return JsonUtility.ToJson(new Serialization<FacilityData>(FacilityList));
    }

    public void AddFacility(FacilityData data)
    {
        IsDirty = true;
        data.Uid = ++UniqueId;
        FacilityList.Add(data);
    }

    public void RemoveFacility(int uid)
    {
        IsDirty = true;
        foreach (var facility in FacilityList)
        {
            if (facility.Uid == uid)
            {
                FacilityList.Remove(facility);
                break;
            }
        }
    }

    public void UpdateFacility(int uid, Vector2Int postion, float rotation)
    {
        IsDirty = true;
        foreach (var facility in FacilityList)
        {
            if (facility.Uid == uid)
            {
                facility.LeftBottom.x = postion.x;
                facility.LeftBottom.y = postion.y;
                facility.Rotation = rotation;
                break;
            }
        }
    }
}