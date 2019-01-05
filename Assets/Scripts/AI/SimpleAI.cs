using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleAI : MonoBehaviour
{
    protected SceneObject Agent;
    protected Vector2Int CurGrid;
    protected Vector2Int MoveTargetGrid;
    protected float MoveTimePreGrid = 2f;

    protected void RandAppear()
    {
        CurGrid = new Vector2Int(Random.Range(5, 15), Random.Range(5, 15));
        transform.position = MapHelper.GridToScenePoint(CurGrid);
    }

    protected void RandMove()
    {
        Vector2Int randGrid;
        do
        {
            var index = Random.Range(0, 4);
            randGrid = CurGrid + MapHelper.NeighborGrids[index];
        } while (randGrid.x < 1 || randGrid.x >= 40 || randGrid.y < 1 || randGrid.y >= 40);
        MoveToGrid(randGrid);
    }

    protected void MoveToGrid(Vector2Int grid)
    {
        var position = MapHelper.GridToScenePoint(grid);
        transform.forward = position - transform.position;
        transform.DOMove(position, MoveTimePreGrid).OnComplete(OnMoveToGridFinish);
        Agent.DoMove();
        MoveTargetGrid = grid;
    }

    protected virtual void OnMoveToGridFinish()
    {
    }

    protected void OnDisappear()
    {
        Destroy(gameObject);
    }
}
