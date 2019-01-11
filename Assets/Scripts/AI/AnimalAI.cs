using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAI : SimpleAI
{
    protected const int TransIdleGridCount = 5;

    public int FenceAreaId;
    protected FenceAreaData FenceAreaData;
    protected int TransIdleGridCountLeft = 0;

    void Start()
    {
        FenceAreaData = GameEntry.Database.FenceArea.GetFenceAreaData(FenceAreaId);
        MoveTimePreGrid = 2f;
        Agent = GetComponent<SceneObject>();
        RandAppear();
        RandMove();
    }

    protected override void RandAppear()
    {
        var index = Random.Range(0, FenceAreaData.Fences.Count);
        CurGrid = FenceAreaData.Fences[index];
        GoParent.transform.position = MapHelper.GridToScenePoint(CurGrid);
        TransIdleGridCountLeft = TransIdleGridCount;
    }

    protected override void RandMove()
    {
        List<Vector2Int> grids = new List<Vector2Int>();
        foreach (var fence in FenceAreaData.Fences)
        {
            if (Mathf.Abs(fence.x - CurGrid.x) + Mathf.Abs(fence.y - CurGrid.y) == 1)
            {
                grids.Add(fence);
            }
        }

        var index = Random.Range(0, grids.Count);
        Vector2Int randGrid = grids[index];
        MoveToGrid(randGrid);
    }

    protected override void OnMoveToGridFinish()
    {
        CurGrid = MoveTargetGrid;
        TransIdleGridCountLeft--;
        if (TransIdleGridCountLeft <= 0)
        {
            Agent.DoIdle();

            var sequence = DOTween.Sequence();
            sequence.AppendInterval(Random.Range(3, 7));
            sequence.AppendCallback(OnIdleFinish);
        }
        else
        {
            RandMove();
        }
    }

    protected void OnIdleFinish()
    {
        TransIdleGridCountLeft = TransIdleGridCount;
        RandMove();
    }
}
