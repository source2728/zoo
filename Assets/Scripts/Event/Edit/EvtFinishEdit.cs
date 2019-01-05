using GameFramework.Event;

public class EvtFinishEdit : GameEventArgs
{
    public static readonly int EventId = typeof(EvtFinishEdit).GetHashCode();
    public override int Id => EventId;

    public bool IsConfirmEdit;

    public override void Clear()
    {
        IsConfirmEdit = false;
    }
}
