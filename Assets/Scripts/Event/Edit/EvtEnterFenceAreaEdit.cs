using GameFramework.Event;

public class EvtEnterFenceAreaEdit : GameEventArgs
{
    public static readonly int EventId = typeof(EvtEnterFenceAreaEdit).GetHashCode();
    public override int Id => EventId;

    public override void Clear()
    {
        
    }
}
