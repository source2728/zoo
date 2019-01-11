using GameFramework.Event;
using UnityEngine;

public class EvtJumpToGrid : GameEventArgs
{
    public static readonly int EventId = typeof(EvtJumpToGrid).GetHashCode();
    public override int Id => EventId;

    public Vector2Int Grid;

    public override void Clear()
    {
    }
}
