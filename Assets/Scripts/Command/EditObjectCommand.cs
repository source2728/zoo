using GameFramework;
using System.Collections.Generic;

public class EditObjectCommand : BaseCommand, IGetCurrencyCost
{
    public List<BuildData> DamageDataList;
    public List<BuildData> EditDataList;

    public override ECommandResult Execute()
    {
        foreach (var data in DamageDataList)
        {
            GameEntry.Database.Shop.RemoveShop(data.BuildUid);
        }

        foreach (var data in EditDataList)
        {
            GameEntry.Database.Shop.UpdateShop(data.BuildUid, data.Rect.position, data.Rotate);
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
            GameEntry.UI.ShowTips("拆除成功！");

            var evt = ReferencePool.Acquire<EvtFinishEdit>();
            evt.IsConfirmEdit = true;
            GameEntry.Event.Fire(this, evt);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 修改名字消耗
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static int GetCost()
    {
        return 0;
    }
    public int GetCurrencyCost()
    {
        return GetCost();
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do(List<BuildData> damageList, List<BuildData> editList)
    {
        var command = new EditObjectCommand();
        command.DamageDataList = damageList;
        command.EditDataList = editList;

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(new CheckCurrencyCommand(command));
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DoCurrencyCostCommand(command));
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
    public static void Do()
    {
        Do(GameEntry.TempData.Edit.DamagingObjectList, GameEntry.TempData.Edit.EditingObjectList);
    }
}
