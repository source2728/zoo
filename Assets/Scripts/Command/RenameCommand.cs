using UnityEngine;
using UnityGameFramework.Runtime;

public class RenameCommand : BaseCommand, IGetCurrencyCost
{
    public enum EType
    {
        Actor,
        Secretary,
        Guard,
        Zoo,
    }

    public EType Type { get; set; }
    public string OriName { get; set; }
    public string NewName { get; set; }

    public override ECommandResult Execute()
    {
        if (OriName == NewName)
        {
            FailType = 1;
            return ECommandResult.Fail;
        }

        switch (Type)
        {
            case EType.Actor:
                GameEntry.Database.Actor.ActorRename(NewName);
                break;

            case EType.Secretary:
                GameEntry.Database.Actor.SecretaryRename(NewName);
                break;

            case EType.Guard:
                GameEntry.Database.Actor.GuardRename(NewName);
                break;

            case EType.Zoo:
                GameEntry.Database.Zoo.Rename(NewName);
                break;
        }
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
            GameEntry.UI.ShowTips("修改名字成功！");
            return true;
        }
        else if (result == ECommandResult.Fail)
        {
            switch (FailType)
            {
                case 1:
                    GameEntry.UI.ShowTips("名字相同，不能修改！");
                    return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 修改名字消耗
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static int GetCurrencyCost(EType type)
    {
        switch (type)
        {
            case EType.Actor:
                return GameEntry.GlobalConfig.GlobalConfigData.ActorRenameCost;

            case EType.Secretary:
                return GameEntry.GlobalConfig.GlobalConfigData.SecretaryRenameCost;

            case EType.Guard:
                return GameEntry.GlobalConfig.GlobalConfigData.GuardRenameCost;

            case EType.Zoo:
                return GameEntry.GlobalConfig.GlobalConfigData.ZooRenameCost;
        }
        return 0;
    }
    public int GetCurrencyCost()
    {
        return GetCurrencyCost(Type);
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do(EType type, string oriName, string newName)
    {
        var command = new RenameCommand();
        command.Type = type;
        command.OriName = oriName;
        command.NewName = newName;

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(new CheckCurrencyCommand(command));
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DoCurrencyCostCommand(command));
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
}
