public class UnlockZooAreaCommand : BaseCommand
{
    public int ZooAreaId;
    public override ECommandResult Execute()
    {
        GameEntry.Database.Zoo.UnlockZooArea(ZooAreaId);
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
            GameEntry.UI.ShowTips("解锁成功！");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do(int areaId)
    {
        var command = new UnlockZooAreaCommand();
        command.ZooAreaId = areaId;

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
}
