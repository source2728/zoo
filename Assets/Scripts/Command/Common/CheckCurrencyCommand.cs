public class CheckCurrencyCommand : BaseCommand
{
    public object Target;

    public CheckCurrencyCommand(object target)
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

        if (checkCurrency.GetCurrencyCost() > GameEntry.Database.Currency.GetCurrencyValue(ECurrencyType.Gold))
        {
            return ECommandResult.NotEnoughCurrency;
        }

        return ECommandResult.Success;
    }
}
