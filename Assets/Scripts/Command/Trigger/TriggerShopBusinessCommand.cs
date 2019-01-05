using DataTable;
using UnityEngine;

public class TriggerShopBusinessCommand : BaseCommand
{
    public override ECommandResult Execute()
    {
        int totalVisitor = GameEntry.Database.Zoo.ZooData.VisitorCount;
        int defaultPrice = 50;

        int totalWeight = 0;
        foreach (var shop in GameEntry.Database.Shop.ShopList)
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DRShop>(shop.Id);
            totalWeight += deploy.Weight;
        }

        foreach (var shop in GameEntry.Database.Shop.ShopList)
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DRShop>(shop.Id);
            shop.TodayVisitor += (int)(Mathf.Pow(10, deploy.Weight / totalWeight) / 50f * totalVisitor);

            var income = Mathf.Pow(10, deploy.Weight / totalWeight) / 10 * Mathf.Pow(0.2f, shop.Price / defaultPrice) * shop.Price * totalVisitor;
            shop.TodayIncome += (int)income;

            GameEntry.Database.Currency.AddCurrencyValue(ECurrencyType.Gold, (int)income);
        }
        GameEntry.Database.Shop.IsDirty = true;

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
//            GameEntry.UI.ShowSecretaryTips("发生突发事件！");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do()
    {
        var command = new TriggerShopBusinessCommand();

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
}
