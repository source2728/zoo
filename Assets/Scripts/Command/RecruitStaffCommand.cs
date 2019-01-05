using DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;

public class RecruitStaffCommand : BaseCommand, IGetCurrencyCost
{
    public DRStaff DRStaff { get; set; }
    public string Name { get; set; }

    public override ECommandResult Execute()
    {
        var data = new StaffData();
        data.Id = DRStaff.Id;
        data.Name = Name;
        GameEntry.Database.Staff.AddStaff(data);
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
            GameEntry.UI.ShowTips("招募成功！");
            return true;
        }
        else if (result == ECommandResult.Fail)
        {
            switch (FailType)
            {
                case 1:
                    GameEntry.UI.ShowTips("名字不能为空！");
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
    public static int GetCost(DRStaff staff)
    {
        return staff.RecruitCost;
    }
    public int GetCurrencyCost()
    {
        return GetCost(DRStaff);
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do(DRStaff staff, string name)
    {
        var command = new RecruitStaffCommand();
        command.DRStaff = staff;
        command.Name = name;

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(new CheckCurrencyCommand(command));
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DoCurrencyCostCommand(command));
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
}
