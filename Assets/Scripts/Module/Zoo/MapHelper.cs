using UnityEngine;

public static class MapHelper
{
    public const float Length = 1f;
    public const float HalfLength = Length / 2;

    public static Vector3 GridToScenePoint(Vector2Int grid)
    {
        Vector3 scenePoint = new Vector3();
        scenePoint.x = grid.x * Length + HalfLength;
        scenePoint.z = grid.y * Length + HalfLength;
        return scenePoint;
    }

    public static Vector3 GridToScenePointLB(Vector2Int grid)
    {
        Vector3 scenePoint = new Vector3();
        scenePoint.x = grid.x * Length;
        scenePoint.z = grid.y * Length;
        return scenePoint;
    }

    public static Vector2Int ScenePointToGrid(Vector3 point)
    {
        Vector2Int grid = new Vector2Int();
        grid.x = Mathf.FloorToInt(point.x / Length);
        grid.y = Mathf.FloorToInt(point.z / Length);
        return grid;
    }

    public readonly static Vector2Int[] NeighborGrids = new Vector2Int[]
    {
        new Vector2Int(0, 1), new Vector2Int(0, -1), new Vector2Int(1, 0), new Vector2Int(-1, 0),
    };
}
