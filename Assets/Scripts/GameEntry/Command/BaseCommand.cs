public class BaseCommand
{
    public int FailType { get; set; }

    public virtual ECommandResult Execute()
    {
        return ECommandResult.Success;
    }

    public virtual bool HandleResult(ECommandResult result)
    {
        return true;
    }
}
