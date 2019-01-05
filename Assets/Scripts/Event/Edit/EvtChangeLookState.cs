using GameFramework.Event;

public class EvtChangeLookState : GameEventArgs
{
    public static readonly int EventId = typeof(EvtChangeLookState).GetHashCode();
    public override int Id => EventId;

    public bool CanLookEditedObject = false;

    public override void Clear()
    {
        CanLookEditedObject = false;
    }
}
