public class SellAnimalCommand : BaseCommand
{
    public int FenceAreaId;
    public int AnimalId;
    public int Count;

    public override ECommandResult Execute()
    {
        var data = GameEntry.Database.FenceArea.GetFenceAreaData(FenceAreaId);
        data.RemoveAnimal(AnimalId, Count);
        GameEntry.Database.FenceArea.IsDirty = true;
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
            GameEntry.UI.ShowTips("出售成功！");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do(int fenceAreaId, int animalId, int count)
    {
        var command = new SellAnimalCommand();
        command.FenceAreaId = fenceAreaId;
        command.AnimalId = animalId;
        command.Count = count;

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
}
