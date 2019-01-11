using DataTable;
using System.Collections.Generic;
using UnityEngine;

public class EditTempData : BaseTempData
{
    public List<BuildData> EditingObjectList { get; private set; } = new List<BuildData>();
    public List<BuildData> DamagingObjectList { get; private set; } = new List<BuildData>();
    public List<Vector2Int> FenceObjectList { get; private set; } = new List<Vector2Int>();

    public List<BuildData> SummaryObjectList { get; private set; } = new List<BuildData>();

    public BuildData SelectedBuildData { get; private set; } = null;

    public EZooObjectType SelectBuildType { get; private set; }
    public int SelectBuildId { get; private set; }
    public int SelectBuildWidth { get; private set; }
    public int SelectBuildHeight { get; private set; }

    public int SelectLandId { get; private set; }
    public int SelectFenceId { get; private set; }

    public Dictionary<int, FenceAreaData> FenceAreaMap { get; private set; } = new Dictionary<int, FenceAreaData>();
    protected int FenceAreaUid = 0;

    public override void ClearData()
    {
        foreach (var editData in SummaryObjectList)
        {
            editData.Count = 0;
        }

        FenceAreaMap.Clear();
        FenceObjectList.Clear();
        EditingObjectList.Clear();
        DamagingObjectList.Clear();
        SummaryObjectList.Clear();
        SelectedBuildData = null;
    }

    public void AddToFenceList(Vector2Int grid)
    {
        FenceObjectList.Add(grid);

        List<int> connectedList = new List<int>();

        foreach (var neighbor in MapHelper.NeighborGrids)
        {
            var neighborGrid = neighbor + grid;
            foreach (var map in FenceAreaMap)
            {
                if (map.Value.HasGrid(neighborGrid.x, neighborGrid.y))
                {
                    if (!connectedList.Contains(map.Key))
                    {
                        connectedList.Add(map.Key);
                    }  
                    break;
                }
            }
        }

        if (connectedList.Count <= 0)
        {
            var fenceArea = new FenceAreaData();
            fenceArea.Fences.Add(grid);
            FenceAreaMap.Add(++FenceAreaUid, fenceArea);
        }
        else if (connectedList.Count == 1)
        {
            FenceAreaMap[connectedList[0]].Fences.Add(grid);
        }
        else
        {
            var fenceArea = new FenceAreaData();
            fenceArea.Fences.Add(grid);
            foreach (var connectedId in connectedList)
            {
                foreach (var fence in FenceAreaMap[connectedId].Fences)
                {
                    fenceArea.Fences.Add(fence);
                }
                FenceAreaMap.Remove(connectedId);
            }
            FenceAreaMap.Add(++FenceAreaUid, fenceArea);
        }
    }

    #region EditList
    public BuildData AddObjectToEditList(Vector2Int leftBottomGrid)
    {
        BuildData buildData = new BuildData();
        buildData.BuildUid = 0;
        buildData.Count = 0;
        buildData.BuildType = (int)SelectBuildType;
        buildData.BuildId = SelectBuildId;
        buildData.Rotate = 0;
        buildData.Rect.x = leftBottomGrid.x;
        buildData.Rect.y = leftBottomGrid.y;
        buildData.Rect.width = SelectBuildWidth;
        buildData.Rect.height = SelectBuildHeight;
        EditingObjectList.Add(buildData);
        return buildData;
    }

    public void AddObjectToEditList(BuildData buildData)
    {
        EditingObjectList.Add(buildData);
    }

    public void RemoveFromEditList(BuildData buildData)
    {
        EditingObjectList.Remove(buildData);
    }

    public void UpdateRotationFromEditList(BuildData buildData, float rotation)
    {
        buildData.Rotate = rotation;
    }

    public void UpdatePositionFromEditList(BuildData buildData, Vector2Int grid)
    {
        buildData.Rect.x = grid.x;
        buildData.Rect.y = grid.y;
    }
    #endregion

    public void AddObjectToDamageList(BuildData buildData)
    {
        DamagingObjectList.Add(buildData);
    }

    #region SummaryObjectList
    public void AddToSummaryList(BuildData buildData)
    {
        BuildData data = null;
        foreach (var editData in SummaryObjectList)
        {
            if (editData.BuildType == buildData.BuildType &&
                editData.BuildId == buildData.BuildId)
            {
                data = editData;
                break;
            }
        }
        if (data == null)
        {
            data = buildData;
            SummaryObjectList.Add(buildData);
        }
        data.Count++;
    }

    public void RemoveFromSummaryList(BuildData buildData)
    {
        BuildData data = null;
        foreach (var editData in SummaryObjectList)
        {
            if (editData.BuildType == buildData.BuildType &&
                editData.BuildId == buildData.BuildId)
            {
                data = editData;
                break;
            }
        }
        if (data != null)
        {
            data.Count--;
            if (data.Count <= 0)
            {
                SummaryObjectList.Remove(buildData);
            }
        }
    }
    #endregion

    public void UpdateSelectBuildInfo(EZooObjectType buildType, int buildId)
    {
        SelectBuildType = buildType;
        SelectBuildId = buildId;

        if (buildId > 0)
        {
            if (buildType == EZooObjectType.FenceArea)
            {
                var deploy = GameEntry.DataTable.GetDataTableRow<DRFence>(buildId);
                SelectBuildWidth = deploy.Width;
                SelectBuildHeight = deploy.Height;
            }
            else if (buildType == EZooObjectType.Shop)
            {
                var deploy = GameEntry.DataTable.GetDataTableRow<DRShop>(buildId);
                SelectBuildWidth = deploy.Width;
                SelectBuildHeight = deploy.Height;
            }
            else if (buildType == EZooObjectType.Facility)
            {
                var deploy = GameEntry.DataTable.GetDataTableRow<DRFacility>(buildId);
                SelectBuildWidth = deploy.Width;
                SelectBuildHeight = deploy.Height;
            }
            else if (buildType == EZooObjectType.Land)
            {
                var deploy = GameEntry.DataTable.GetDataTableRow<DRLand>(buildId);
                SelectBuildWidth = deploy.Width;
                SelectBuildHeight = deploy.Height;
            }
        }
        else
        {
            SelectBuildWidth = 0;
            SelectBuildHeight = 0;
        }
    }
    public void UpdateSelectBuildInfo(int buildId)
    {
        UpdateSelectBuildInfo(SelectBuildType, buildId);
    }

    public void SetSelectedBuildData(BuildData buildData)
    {
        SelectedBuildData = buildData;
    }

    public void UpdateSelectFenceAreaInfo(int landId, int fenceId)
    {
        SelectBuildType = EZooObjectType.FenceArea;
        SelectBuildId = fenceId;
        SelectLandId = landId;
        SelectFenceId = fenceId;
        SelectBuildWidth = 1;
        SelectBuildHeight = 1;
    }
}