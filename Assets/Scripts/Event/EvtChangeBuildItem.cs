using GameFramework.Event;

public class EvtChangeBuildItem : GameEventArgs
{
    public static readonly int EventId = typeof(EvtChangeBuildItem).GetHashCode();
    public override int Id => EventId;

    public EZooObjectType ObjectType { get; set; }
    public int ObjectId { get; set; }

    public override void Clear()
    {
        
    }
}
