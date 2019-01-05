using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DefaultLocalData : ScriptableObject
{
    public int Money;
    public List<string> SecretaryDialogs;
    public List<string> GuardDialogs;
    public ActorData ActorData;
    public ZooData ZooData;

    public string RandSecretaryDialog()
    {
        int index = Random.Range(0, SecretaryDialogs.Count);
        return SecretaryDialogs[index];
    }

    public string RandGuardDialog()
    {
        int index = Random.Range(0, GuardDialogs.Count);
        return GuardDialogs[index];
    }
}
