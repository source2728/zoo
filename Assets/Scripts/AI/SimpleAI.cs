using System;
using System.Collections.Generic;
using DataTable;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleAI : MonoBehaviour
{
    public SceneObject Agent;
    public GameObject GoParent;

    protected Vector2Int CurGrid;
    protected Vector2Int MoveTargetGrid;
    protected float MoveTimePreGrid = 2f;

    protected virtual void RandAppear()
    {
        do
        {
            CurGrid = new Vector2Int(Random.Range(5, 15), Random.Range(5, 15));
        } while (!CheckGridMovable(CurGrid));

        GoParent.transform.position = MapHelper.GridToScenePoint(CurGrid);
    }

    protected virtual void RandMove()
    {
        Vector2Int randGrid = new Vector2Int();
        List<int> indexs = new List<int>() {0, 1, 2, 3};
        int index = -1;
        do
        {
            if (index >= 0)
            {
                indexs.RemoveAt(index);
            }

            if (indexs.Count <= 0)
            {
                break;
            }

            index = Random.Range(0, indexs.Count);
            randGrid = CurGrid + MapHelper.NeighborGrids[indexs[index]];
        } while (!CheckGridMovable(randGrid));

        if (randGrid.x != 0 && randGrid.y != 0)
        {
            MoveToGrid(randGrid);
        }
        else
        {
            Agent.DoIdle();
            var sequence = DOTween.Sequence();
            sequence.AppendInterval(1);
            sequence.AppendCallback(OnMoveToGridFinish);
        }
    }

    protected bool CheckGridMovable(Vector2Int grid)
    {
        foreach (var areaData in GameEntry.Database.FenceArea.FenceAreaList)
        {
            foreach (var fence in areaData.Fences)
            {
                if (fence == grid)
                {
                    return false;
                }
            }
        }

        foreach (var shopData in GameEntry.Database.Shop.ShopList)
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DRShop>(shopData.Id);
            RectInt rect = new RectInt(shopData.LeftBottom, new Vector2Int(deploy.Width, deploy.Height));
            if (rect.Contains(grid))
            {
                return false;
            }
        }

        return !(grid.x < 1 || grid.x >= 40 || grid.y < 1 || grid.y >= 40);
    }

    protected void MoveToGrid(Vector2Int grid)
    {
        var position = MapHelper.GridToScenePoint(grid);
        GoParent.transform.forward = position - GoParent.transform.position;
        GoParent.transform.DOMove(position, MoveTimePreGrid).OnComplete(OnMoveToGridFinish);
        Agent.DoMove();
        MoveTargetGrid = grid;
    }

    protected virtual void OnMoveToGridFinish()
    {
    }

    protected virtual void OnDisappear()
    {
        Destroy(GoParent);
    }
}
