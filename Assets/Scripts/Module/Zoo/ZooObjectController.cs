using DataTable;
using GameFramework.Resource;
using UnityEngine;

public enum EZooObjectState
{
    Normal,
    BuildPreview,
    DamagePreview,
}

public class ZooObjectController : MonoBehaviour
{
    public BuildData BuildData { get; set; }
    public GameObject BuildObject;
    public Material CurMaterial;

    void Start()
    {
        var m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadUIFormSuccessCallback);

        if (BuildData.BuildType == (int) EZooObjectType.FenceArea)
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DRFenceArea>(BuildData.BuildId);
            GameEntry.Resource.LoadAsset(deploy.ModelPath, m_LoadAssetCallbacks);
        }
        else if (BuildData.BuildType == (int)EZooObjectType.Shop)
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DRShop>(BuildData.BuildId);
            GameEntry.Resource.LoadAsset(deploy.ModelPath, m_LoadAssetCallbacks);
        }
        else if (BuildData.BuildType == (int)EZooObjectType.Fence)
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DRFence>(BuildData.BuildId);
            GameEntry.Resource.LoadAsset(deploy.StakeModelPath, m_LoadAssetCallbacks);
        }
        else if (BuildData.BuildType == (int)EZooObjectType.FenceConnect)
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DRFence>(BuildData.BuildId);
            GameEntry.Resource.LoadAsset(deploy.WoodModelPath, m_LoadAssetCallbacks);
        }
        else if (BuildData.BuildType == (int)EZooObjectType.Facility)
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DRFacility>(BuildData.BuildId);
            GameEntry.Resource.LoadAsset(deploy.ModelPath, m_LoadAssetCallbacks);
        }
        else if (BuildData.BuildType == (int)EZooObjectType.Land)
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DRLand>(BuildData.BuildId);
            GameEntry.Resource.LoadAsset(deploy.ModelPath, m_LoadAssetCallbacks);
        }
    }

    private void LoadUIFormSuccessCallback(string assetName, object asset, float duration, object userData)
    {
        var newObject = Instantiate(asset as GameObject);
        newObject.transform.SetParent(transform);
        newObject.transform.localPosition = Vector3.zero;
        newObject.transform.localRotation = Quaternion.Euler(0, BuildData.Rotate, 0);
        BuildObject = newObject;
        UpdatePosition();
        UpdateMaterial(CurMaterial);
    }

    public void UpdateRotation()
    {
        if (BuildObject != null)
        {
            BuildObject.transform.localRotation = Quaternion.Euler(0, BuildData.Rotate, 0);
        }
    }

    public void UpdatePosition()
    {
        if (BuildData.BuildType == (int) EZooObjectType.Fence)
        {
            var scenePoint = MapHelper.GridToScenePointLB(BuildData.Rect.position);
            transform.localPosition = scenePoint;
        }
        else if (BuildData.BuildType == (int)EZooObjectType.FenceConnect)
        {
            var tmp = BuildData.Rect.position.y % 10;
            if (tmp > 0)
            {
                var scenePoint = MapHelper.GridToScenePointLB(BuildData.Rect.position);
                transform.localPosition = scenePoint / 10 - new Vector3(0, 0, MapHelper.HalfLength);
                transform.localRotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                var scenePoint = MapHelper.GridToScenePointLB(BuildData.Rect.position);
                transform.localPosition = scenePoint / 10 + new Vector3(MapHelper.HalfLength, 0, 0);
            }
        }
        else
        {
            Vector3 lbScenePoint = MapHelper.GridToScenePoint(BuildData.Rect.position);
            Vector3 rtScenePoint = MapHelper.GridToScenePoint(BuildData.Rect.max - new Vector2Int(1, 1));
            Vector3 scenePoint = (lbScenePoint + rtScenePoint) / 2;
            transform.localPosition = scenePoint;
        }
    }

    public void UpdateMaterial(Material material)
    {
        CurMaterial = material;
        if (BuildObject == null)
            return;

        if (BuildData.BuildType != (int)EZooObjectType.Fence &&
            BuildData.BuildType != (int)EZooObjectType.FenceConnect &&
            BuildData.BuildType != (int)EZooObjectType.FenceArea &&
            BuildData.BuildType != (int)EZooObjectType.Land)
        {
            var ddd = BuildObject.GetComponentInChildren<MeshRenderer>();
            ddd.material = material;
        }
    }
}
