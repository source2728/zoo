using GameFramework.Event;

public class EvtZooBusinessTriggered : GameEventArgs
{
    public static readonly int EventId = typeof(EvtZooBusinessTriggered).GetHashCode();
    public override int Id => EventId;

    public override void Clear()
    {
    }
}
