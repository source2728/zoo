using DataTable;
using GameFramework.Resource;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public int FenceAreaId;
    public int AnimalId;

    void Start()
    {
        var m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadUIFormSuccessCallback);
        var deploy = GameEntry.DataTable.GetDataTableRow<DRAnimal>(AnimalId);
        GameEntry.Resource.LoadAsset(deploy.ModelPath, m_LoadAssetCallbacks);
    }

    private void LoadUIFormSuccessCallback(string assetName, object asset, float duration, object userData)
    {
        var newObject = Instantiate(asset as GameObject);
        newObject.transform.SetParent(transform);
        newObject.transform.localPosition = Vector3.zero;
        newObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

        var ai = newObject.AddComponent<AnimalAI>();
        ai.Agent = newObject.GetComponent<SceneObject>();
        ai.GoParent = gameObject;
        ai.FenceAreaId = FenceAreaId;
    }
}
