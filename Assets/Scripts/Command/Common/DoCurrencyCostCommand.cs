public class DoCurrencyCostCommand : BaseCommand
{
    public object Target;

    public DoCurrencyCostCommand(object target)
    {
        Target = target;
    }

    public override ECommandResult Execute()
    {
        if (Target == null)
        {
            return ECommandResult.ParameterError;
        }

        var checkCurrency = Target as IGetCurrencyCost;
        if (checkCurrency == null)
        {
            return ECommandResult.ParameterError;
        }

        var gold = GameEntry.Database.Currency.GetCurrencyValue(ECurrencyType.Gold);
        var cost = checkCurrency.GetCurrencyCost();
        GameEntry.Database.Currency.SetCurrencyValue(ECurrencyType.Gold, gold - cost);
        return ECommandResult.Success;
    }
}
