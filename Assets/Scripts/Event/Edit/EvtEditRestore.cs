using GameFramework.Event;

public class EvtEditRestore : GameEventArgs
{
    public static readonly int EventId = typeof(EvtEditRestore).GetHashCode();
    public override int Id => EventId;

    public BuildData BuildData;
    public ZooObjectController ZooObjectController;

    public override void Clear()
    {
    }
}
