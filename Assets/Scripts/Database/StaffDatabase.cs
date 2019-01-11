using System.Collections.Generic;
using UnityEngine;

public class StaffDatabase : BaseDatabase
{
    protected List<StaffData> m_StaffList = new List<StaffData>();
    public List<StaffData> StaffList
    {
        get { return m_StaffList; }
    }

    public int UniqueId = 0;

    public override void ClearData()
    {
        m_StaffList.Clear();
        UniqueId = 0;
    }

    public override void LoadDataFromJson(string json)
    {
        m_StaffList = JsonUtility.FromJson<Serialization<StaffData>>(json).ToList();
        foreach (var staff in m_StaffList)
        {
            if (staff.Uid > UniqueId)
            {
                UniqueId = staff.Uid;
            }
        }
    }

    public override void LoadDataFromDefault(DefaultLocalData data)
    {
    }

    public override string SaveDataAsJson()
    {
        return JsonUtility.ToJson(new Serialization<StaffData>(m_StaffList));
    }

    public StaffData GetStaffData(int uid)
    {
        foreach (var data in m_StaffList)
        {
            if (data.Uid == uid)
                return data;
        }

        return null;
    }

    public void AddStaff(StaffData data)
    {
        IsDirty = true;
        data.Uid = ++UniqueId;
        m_StaffList.Add(data);
    }

    public void RemoveStaff(StaffData data)
    {
        IsDirty = true;
        m_StaffList.Remove(data);
    }
}