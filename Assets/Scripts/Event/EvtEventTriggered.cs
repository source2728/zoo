using GameFramework.Event;

public class EvtEventTriggered : GameEventArgs
{
    public static readonly int EventId = typeof(EvtEventTriggered).GetHashCode();
    public override int Id => EventId;

    public int ZooEventId;

    public override void Clear()
    {
        ZooEventId = 0;
    }
}
