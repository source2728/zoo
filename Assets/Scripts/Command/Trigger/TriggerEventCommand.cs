using UnityEngine;
using UnityGameFramework.Runtime;

public class TriggerEventCommand : BaseCommand
{
    public int EventId { get; set; }

    public override ECommandResult Execute()
    {
        GameEntry.Database.Event.AddEvent(EventId);
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
            GameEntry.UI.ShowSecretaryTips("发生突发事件！");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do(int eventId)
    {
        var command = new TriggerEventCommand();
        command.EventId = eventId;

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
}
