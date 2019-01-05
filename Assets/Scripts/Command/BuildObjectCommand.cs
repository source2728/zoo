using GameFramework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildObjectCommand : BaseCommand, IGetCurrencyCost
{
    public List<BuildData> DataList;
    public List<FenceAreaData> FenceAreaList;

    public override ECommandResult Execute()
    {
        foreach (var data in DataList)
        {
            if (data.BuildType == (int)EZooObjectType.Shop)
            {
                var shopData = new ShopData();
                shopData.Name = "123";
                shopData.LeftBottom = data.Rect.position;
                shopData.Price = 1;
                shopData.TodayIncome = 2;
                shopData.TodayVisitor = 3;
                shopData.Id = data.BuildId;
                shopData.Rotation = data.Rotate;
                GameEntry.Database.Shop.AddShop(shopData);
            }
            else if (data.BuildType == (int) EZooObjectType.Facility)
            {
                var facilityData = new FacilityData();
                facilityData.Id = data.BuildId;
                facilityData.LeftBottom = data.Rect.position;
                facilityData.Rotation = data.Rotate;
                GameEntry.Database.Facility.AddFacility(facilityData);
            }
            else if (data.BuildType == (int)EZooObjectType.Land)
            {
                var landData = new LandData();
                landData.Id = data.BuildId;
                landData.LeftBottom = data.Rect.position;
                landData.Rotation = data.Rotate;
                GameEntry.Database.Land.AddLand(landData);
            }
        }

        foreach (var data in FenceAreaList)
        {
            GameEntry.Database.FenceArea.AddFenceArea(data);
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
            GameEntry.UI.ShowTips("建造成功！");

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
    public static void Do(List<BuildData> datas, List<FenceAreaData> fenceAreas)
    {
        var command = new BuildObjectCommand();
        command.DataList = datas;
        command.FenceAreaList = fenceAreas;

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(new CheckCurrencyCommand(command));
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DoCurrencyCostCommand(command));
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
    public static void Do()
    {
        Do(GameEntry.TempData.Edit.EditingObjectList, GameEntry.TempData.Edit.FenceAreaMap.Values.ToList());
    }
}
