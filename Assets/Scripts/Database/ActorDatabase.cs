using System.Collections.Generic;
using UnityEngine;

public class ActorDatabase : BaseDatabase
{
    public ActorData ActorData { get; set; }

    public override void ClearData()
    {
        ActorData = new ActorData();
    }

    public override void LoadDataFromJson(string json)
    {
        ActorData = JsonUtility.FromJson<ActorData>(json);
    }

    public override void LoadDataFromDefault(DefaultLocalData data)
    {
        ActorData.Fill(data.ActorData);
    }

    public override string SaveDataAsJson()
    {
        return JsonUtility.ToJson(ActorData);
    }

    public void ActorRename(string newName)
    {
        IsDirty = true;
        ActorData.ActorName = newName;
    }

    public void SecretaryRename(string newName)
    {
        IsDirty = true;
        ActorData.SecretaryName = newName;
    }

    public void GuardRename(string newName)
    {
        IsDirty = true;
        ActorData.GuardName = newName;
    }
}