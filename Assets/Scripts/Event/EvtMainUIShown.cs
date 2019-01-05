using GameFramework.Event;

public class EvtMainUIShown : GameEventArgs
{
    public static readonly int EventId = typeof(EvtMainUIShown).GetHashCode();
    public override int Id => EventId;

    public override void Clear()
    {
        
    }
}
