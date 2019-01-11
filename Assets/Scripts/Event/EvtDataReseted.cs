using GameFramework.Event;

public class EvtDataReseted : GameEventArgs
{
    public static readonly int EventId = typeof(EvtDataReseted).GetHashCode();
    public override int Id => EventId;

    public override void Clear()
    {
        
    }
}
