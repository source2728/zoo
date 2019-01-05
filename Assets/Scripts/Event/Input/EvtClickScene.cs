using GameFramework.Event;
using UnityEngine;

public class EvtClickScene : GameEventArgs
{
    public static readonly int EventId = typeof(EvtClickScene).GetHashCode();

    public override int Id => EventId;

    public Vector3 Point { get; set; }

    public override void Clear()
    {
        Point = default(Vector3);
    }
}
