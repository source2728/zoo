using GameFramework.Event;

public class EvtConfirmEdit : GameEventArgs
{
    public static readonly int EventId = typeof(EvtConfirmEdit).GetHashCode();
    public override int Id => EventId;

    public override void Clear()
    {
    }
}
