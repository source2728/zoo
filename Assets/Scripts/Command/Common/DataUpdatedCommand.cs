using GameFramework;

public class DataUpdatedCommand : BaseCommand
{
    public override ECommandResult Execute()
    {
        GameEntry.Database.DataUpdated();
        return ECommandResult.Success;
    }
}
