using DataTable;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

public class TriggerZooBusinessCommand : BaseCommand
{
    public override ECommandResult Execute()
    {
        var zooData = GameEntry.Database.Zoo.ZooData;

        int animalCount = zooData.AnimalCount + 1;
        int animalHappiness = Random.Range(70, 80);
        int visitorCount = animalCount * animalHappiness / 20;
        int newVisitorCount = visitorCount - zooData.VisitorCount;
        int income = zooData.Price * newVisitorCount;

        zooData.AnimalCount = animalCount;
        zooData.AnimalHappiness = animalHappiness;
        zooData.VisitorLike = zooData.AnimalCount * zooData.AnimalHappiness * 2;
        zooData.VisitorCount = visitorCount;
        zooData.ExpectIncome += income;

        GameEntry.Database.Zoo.IsDirty = true;
        GameEntry.Database.Currency.AddCurrencyValue(ECurrencyType.Gold, income);
        return ECommandResult.Success;
    }

    /// <summary>
    /// 处理结果
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public override bool HandleResult(ECommandResult result)
    {
        if (result == ECommandResult.Success)
        {
            var evt = ReferencePool.Acquire<EvtZooBusinessTriggered>();
            GameEntry.Event.Fire(this, evt);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do()
    {
        var command = new TriggerZooBusinessCommand();

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
}
