using GameFramework.Event;

public class EvtChangeTouchState : GameEventArgs
{
    public static readonly int EventId = typeof(EvtChangeTouchState).GetHashCode();
    public override int Id => EventId;

    public bool CanSwipeScene = true;

    public override void Clear()
    {
        CanSwipeScene = true;
    }
}
