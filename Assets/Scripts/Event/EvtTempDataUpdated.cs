using GameFramework.Event;

public class EvtTempDataUpdated : GameEventArgs
{
    public static readonly int EventId = typeof(EvtTempDataUpdated).GetHashCode();
    public override int Id => EventId;

    public override void Clear()
    {
        
    }
}
