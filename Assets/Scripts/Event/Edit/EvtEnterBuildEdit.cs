using GameFramework.Event;

public class EvtEnterBuildEdit : GameEventArgs
{
    public static readonly int EventId = typeof(EvtEnterBuildEdit).GetHashCode();

    public override int Id => EventId;

    public override void Clear()
    {
        
    }
}
