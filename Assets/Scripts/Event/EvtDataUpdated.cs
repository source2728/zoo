using GameFramework.Event;

public class EvtDataUpdated : GameEventArgs
{
    public static readonly int EventId = typeof(EvtDataUpdated).GetHashCode();

    public override int Id => EventId;

    public override void Clear()
    {
        
    }
}
