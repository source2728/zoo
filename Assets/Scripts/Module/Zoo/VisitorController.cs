using DataTable;
using GameFramework.Resource;
using UnityEngine;

public class VisitorController : MonoBehaviour
{
    protected const string ModulePath = "Assets/Arts/Prefab/Charactor/yk.prefab";

    void Start()
    {
        var m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadUIFormSuccessCallback);
        GameEntry.Resource.LoadAsset(ModulePath, m_LoadAssetCallbacks);
    }

    private void LoadUIFormSuccessCallback(string assetName, object asset, float duration, object userData)
    {
        var newObject = Instantiate(asset as GameObject);
        newObject.transform.SetParent(transform);
        newObject.transform.localPosition = Vector3.zero;
        newObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

        var ai = newObject.AddComponent<VisitorAI>();
        ai.Agent = newObject.GetComponent<SceneObject>();
        ai.GoParent = gameObject;
    }
}
