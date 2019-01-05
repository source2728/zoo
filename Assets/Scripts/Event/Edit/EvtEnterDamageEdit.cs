using GameFramework.Event;

public class EvtEnterDamageEdit : GameEventArgs
{
    public static readonly int EventId = typeof(EvtEnterDamageEdit).GetHashCode();

    public override int Id => EventId;

    public override void Clear()
    {
        
    }
}
