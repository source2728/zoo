public class DefaultResultHandler : ICommandResultHandler
{
    public void HandleResult(ECommandResult result)
    {
        switch (result)
        {
            case ECommandResult.NotEnoughCurrency:
                GameEntry.UI.ShowTips("金币不足！");
                break;
        }
    }
}
