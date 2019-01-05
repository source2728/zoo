using UnityEngine;
using UnityGameFramework.Runtime;

public class SetShopPriceCommand : BaseCommand
{
    public int ShopId { get; set; }
    public int NewPrice { get; set; }

    public override ECommandResult Execute()
    {
        var shop = GameEntry.Database.Shop.GetShop(ShopId);
        shop.Price = NewPrice;
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
            GameEntry.UI.ShowTips("设置成功！");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 创建指令
    /// </summary>
    public static void Do(int shopId, int newPrice)
    {
        var command = new SetShopPriceCommand();
        command.NewPrice = newPrice;
        command.ShopId = shopId;

        var sequence = GameEntry.Command.Sequence();
        sequence.AppendCommand(command);
        sequence.AppendCommand(new DataUpdatedCommand());
        sequence.AppendResultHandler(command.HandleResult);
    }
}
