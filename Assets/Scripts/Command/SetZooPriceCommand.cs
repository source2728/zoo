using UnityEngine;
using UnityGameFramework.Runtime;

public class SetZooPriceCommand : BaseCommand
{
    public int NewPrice { get; set; }

    public override ECommandResult Execute()
    {
        GameEntry.Database.Zoo.SetPrice(NewPrice);
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
            GameEntry.UI.ShowTips("设置成功！");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do(int newPrice)
    {
        var command = new SetZooPriceCommand();
        command.NewPrice = newPrice;

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
}
