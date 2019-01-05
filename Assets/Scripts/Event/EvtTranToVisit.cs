using GameFramework.Event;

public class EvtTranToVisit : GameEventArgs
{
    public static readonly int EventId = typeof(EvtTranToVisit).GetHashCode();

    public override int Id => EventId;

    public override void Clear()
    {
        
    }
}
