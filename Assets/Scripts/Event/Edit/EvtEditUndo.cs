using GameFramework.Event;

public class EvtEditUndo : GameEventArgs
{
    public static readonly int EventId = typeof(EvtEditUndo).GetHashCode();
    public override int Id => EventId;

    public override void Clear()
    {
    }
}
