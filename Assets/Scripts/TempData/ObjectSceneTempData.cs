using DataTable;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSceneTempData : BaseTempData
{
    public Dictionary<int, SceneObjectData> SceneObjectMap { get; } = new Dictionary<int, SceneObjectData>();
    public List<int> DirtyList = new List<int>();
    private int SceneUid = 0;

    protected Dictionary<int, BuildData> BuildedInfoMap = new Dictionary<int, BuildData>();

    public override void ClearData()
    {
        BuildedInfoMap.Clear();
        SceneObjectMap.Clear();
        DirtyList.Clear();
    }

    public void AddShopInfo(ShopData shopData)
    {
        var deploy = GameEntry.DataTable.GetDataTableRow<DRShop>(shopData.Id);

        // 创建对象数据
        BuildData buildData = new BuildData();
        buildData.BuildType = (int)EZooObjectType.Shop;
        buildData.BuildId = shopData.Id;
        buildData.BuildUid = shopData.Uid;
        buildData.Rotate = shopData.Rotation;
        buildData.Rect.x = shopData.LeftBottom.x;
        buildData.Rect.y = shopData.LeftBottom.y;
        buildData.Rect.width = deploy.Width;
        buildData.Rect.height = deploy.Height;
        AddBuildInfo(buildData, ESceneObjectStatus.Builded);
    }

    public void AddFacilityInfo(FacilityData facilityData)
    {
        var deploy = GameEntry.DataTable.GetDataTableRow<DRFacility>(facilityData.Id);

        BuildData buildData = new BuildData();
        buildData.BuildType = (int)EZooObjectType.Facility;
        buildData.BuildId = facilityData.Id;
        buildData.BuildUid = facilityData.Uid;
        buildData.Rotate = facilityData.Rotation;
        buildData.Rect.x = facilityData.LeftBottom.x;
        buildData.Rect.y = facilityData.LeftBottom.y;
        buildData.Rect.width = deploy.Width;
        buildData.Rect.height = deploy.Height;
        AddBuildInfo(buildData, ESceneObjectStatus.Builded);
    }

    public void AddLandInfo(LandData landData)
    {
        var deploy = GameEntry.DataTable.GetDataTableRow<DRLand>(landData.Id);

        BuildData buildData = new BuildData();
        buildData.BuildType = (int)EZooObjectType.Land;
        buildData.BuildId = landData.Id;
        buildData.BuildUid = landData.Uid;
        buildData.Rotate = landData.Rotation;
        buildData.Rect.x = landData.LeftBottom.x;
        buildData.Rect.y = landData.LeftBottom.y;
        buildData.Rect.width = deploy.Width;
        buildData.Rect.height = deploy.Height;
        AddBuildInfo(buildData, ESceneObjectStatus.Builded);
    }

    public void AddFenceArea(FenceAreaData data)
    {
        foreach (var fence in data.Fences)
        {
            BuildData buildData = new BuildData();
            buildData.BuildType = (int)EZooObjectType.FenceArea;
            buildData.BuildId = 1;
            buildData.BuildUid = 0;
            buildData.Rotate = 0;
            buildData.Rect.x = fence.x;
            buildData.Rect.y = fence.y;
            buildData.Rect.width = 1;
            buildData.Rect.height = 1;
            AddBuildInfo(buildData, ESceneObjectStatus.Builded);
        }

        var fenceList = data.GetFences();
        foreach (var pos in fenceList)
        {
            BuildData buildData = new BuildData();
            buildData.BuildType = (int)EZooObjectType.Fence;
            buildData.BuildId = 1;
            buildData.BuildUid = 0;
            buildData.Rotate = 0;
            buildData.Rect.x = pos.x;
            buildData.Rect.y = pos.y;
            buildData.Rect.width = 1;
            buildData.Rect.height = 1;
            AddBuildInfo(buildData, ESceneObjectStatus.Builded);
        }

        var connectList = data.GetFenceConnects();
        foreach (var pos in connectList)
        {
            BuildData buildData = new BuildData();
            buildData.BuildType = (int)EZooObjectType.FenceConnect;
            buildData.BuildId = 1;
            buildData.BuildUid = 0;
            buildData.Rotate = 0;
            buildData.Rect.x = (int)(pos.x * 10);
            buildData.Rect.y = (int)(pos.y * 10);
            buildData.Rect.width = 1;
            buildData.Rect.height = 1;
            AddBuildInfo(buildData, ESceneObjectStatus.Builded);
        }
    }

    public void AddBuildInfo(BuildData buildData, ESceneObjectStatus status)
    {
        SceneObjectData data = new SceneObjectData();
        data.BuildData = buildData;
        data.ObjectUid = ++SceneUid;
        data.Status = status;
        SceneObjectMap.Add(data.ObjectUid, data);

        buildData.BuildSceneUid = data.ObjectUid;
        DirtyList.Add(data.ObjectUid);
    }

    public void RemoveBuildInfo(BuildData buildData)
    {
        SceneObjectMap.Remove(buildData.BuildSceneUid);
        DirtyList.Add(buildData.BuildSceneUid);
    }

    public void RemoveBuildInfoByEdit(int uid)
    {
        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(uid);
        AddToBuildedMap(data);
        data.Status = ESceneObjectStatus.Remove;
        DirtyList.Add(uid);
    }

    public void UpdateBuildInfoByEdit(int uid, Vector2Int grid)
    {
        var data = GetSceneObjectData(uid);
        if (data != null)
        {
            AddToBuildedMap(data);
            data.Status = ESceneObjectStatus.Edit;
            data.BuildData.Rect.x = grid.x;
            data.BuildData.Rect.y = grid.y;
        }
    }

    public void UpdateBuildInfoByEdit(int uid, float rotation)
    {
        var data = GetSceneObjectData(uid);
        if (data != null)
        {
            AddToBuildedMap(data);
            data.Status = ESceneObjectStatus.Edit;
            data.BuildData.Rotate = rotation;
        }
    }

    protected void AddToBuildedMap(SceneObjectData data)
    {
        if (data.Status == ESceneObjectStatus.Builded)
        {
            BuildData buildData = new BuildData();
            buildData.Rect.position = data.BuildData.Rect.position;
            buildData.Rotate = data.BuildData.Rotate;
            BuildedInfoMap.Add(data.ObjectUid, buildData);
        }
    }

    public SceneObjectData GetSceneObjectData(int uid)
    {
        SceneObjectData sceneObjectData;
        if (SceneObjectMap.TryGetValue(uid, out sceneObjectData))
        {
            return sceneObjectData;
        }
        return null;
    }

    public SceneObjectData GetSceneObjectData(Vector2Int grid)
    {
        return GetSceneObjectData(grid, 1, 1);
    }

    public SceneObjectData GetSceneObjectData(Vector2Int grid, int width, int height)
    {
        RectInt rect = new RectInt(grid.x, grid.y, width, height);
        foreach (var map in SceneObjectMap)
        {
            var buildData = map.Value.BuildData;
            if (Mathf.Abs(rect.x - buildData.Rect.x) < rect.width * 0.5f + buildData.Rect.width * 0.5f
                && Mathf.Abs(rect.y - buildData.Rect.y) < rect.height * 0.5f + buildData.Rect.height * 0.5f)
            {
                return map.Value;
            }
        }
        return null;
    }

    public void ConfirmEditToBuilded()
    {
        DirtyList.Clear();
        foreach (var map in SceneObjectMap)
        {
            if (map.Value.Status == ESceneObjectStatus.Add)
            {
                map.Value.Status = ESceneObjectStatus.Builded;
                DirtyList.Add(map.Key);
            }
        }
        BuildedInfoMap.Clear();
    }

    public void ConfirmEditToEdited()
    {
        List<int> deleteList = new List<int>();
        DirtyList.Clear();
        foreach (var map in SceneObjectMap)
        {
            if (map.Value.Status == ESceneObjectStatus.Remove)
            {
                deleteList.Add(map.Key);
                DirtyList.Add(map.Key);
            }
            else
            {
                map.Value.Status = ESceneObjectStatus.Builded;
                DirtyList.Add(map.Key);
            }
        }
        foreach (var uid in deleteList)
        {
            SceneObjectMap.Remove(uid);
        }
        BuildedInfoMap.Clear();
    }

    public void CancelEdit()
    {
        List<int> deleteList = new List<int>();
        foreach (var map in SceneObjectMap)
        {
            if (map.Value.Status == ESceneObjectStatus.Add)
            {
                deleteList.Add(map.Key);
                DirtyList.Add(map.Key);
            }
            else if (map.Value.Status != ESceneObjectStatus.Builded)
            {
                var data = BuildedInfoMap[map.Key];
                map.Value.BuildData.Rect.position = data.Rect.position;
                map.Value.BuildData.Rotate = data.Rotate;
                map.Value.Status = ESceneObjectStatus.Builded;
                DirtyList.Add(map.Key);
            }
        }

        foreach (var uid in deleteList)
        {
            SceneObjectMap.Remove(uid);
        }
        BuildedInfoMap.Clear();
    }
}