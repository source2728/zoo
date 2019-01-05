using DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;

public class FireStaffCommand : BaseCommand, IGetCurrencyCost
{
    public StaffData StaffData { get; set; }

    public override ECommandResult Execute()
    {
        GameEntry.Database.Staff.RemoveStaff(StaffData);
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
            GameEntry.UI.ShowTips("解雇成功！");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 修改名字消耗
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static int GetCost(int id)
    {
        return GameEntry.DataTable.GetDataTableRow<DRStaff>(id).FireCost;
    }
    public int GetCurrencyCost()
    {
        return GetCost(StaffData.Id);
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do(StaffData staffData)
    {
        var command = new FireStaffCommand();
        command.StaffData = staffData;

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(new CheckCurrencyCommand(command));
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DoCurrencyCostCommand(command));
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
}
