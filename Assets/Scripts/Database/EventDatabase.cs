using System.Collections.Generic;
using UnityEngine;

public class EventDatabase : BaseDatabase
{
    protected List<int> EventList { get; set; } = new List<int>();

    public override void ClearData()
    {
        EventList.Clear();
    }

    public override void LoadDataFromJson(string json)
    {
        EventList = JsonUtility.FromJson<Serialization<int>>(json).ToList();
    }

    public override void LoadDataFromDefault(DefaultLocalData data)
    {
    }

    public override string SaveDataAsJson()
    {
        return JsonUtility.ToJson(new Serialization<int>(EventList));
    }

    public void AddEvent(int eventId)
    {
        IsDirty = true;
        EventList.Add(eventId);
    }
}