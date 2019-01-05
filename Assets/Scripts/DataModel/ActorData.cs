using System;

[Serializable]
public class ActorData
{
    public string ActorName;
    public int ActorPopular;
    public int IncomeBonus;

    public string SecretaryName;
    public string GuardName;
    public string ActorHonorName;

    public void Fill(ActorData data)
    {
        ActorName = data.ActorName;
        ActorPopular = data.ActorPopular;
        IncomeBonus = data.IncomeBonus;
        SecretaryName = data.SecretaryName;
        GuardName = data.GuardName;
        ActorHonorName = data.ActorHonorName;
    }
}
