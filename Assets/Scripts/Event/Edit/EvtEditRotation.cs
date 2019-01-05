using GameFramework.Event;

public class EvtEditRotation : GameEventArgs
{
    public static readonly int EventId = typeof(EvtEditRotation).GetHashCode();
    public override int Id => EventId;

    public BuildData BuildData;
    public ZooObjectController ZooObjectController;

    public override void Clear()
    {
    }
}
