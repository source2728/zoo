using DataTable;
using GameFramework.Resource;
using UnityEngine;

public class StaffController : MonoBehaviour
{
    void Start()
    {
//        var m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadUIFormSuccessCallback);
//        var deploy = GameEntry.DataTable.GetDataTableRow<DREvent>(EventId);
//        GameEntry.Resource.LoadAsset(deploy.ModulePath, m_LoadAssetCallbacks);
    }

    private void LoadUIFormSuccessCallback(string assetName, object asset, float duration, object userData)
    {
//        var newObject = Instantiate(asset as GameObject);
//        newObject.transform.SetParent(transform);
//        newObject.transform.localPosition = Vector3.zero;
//        newObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
//
//        if (EventId == 1)
//        {
//            var ai = newObject.AddComponent<ThiefAI>();
//            ai.Agent = newObject.GetComponent<SceneObject>();
//            ai.GoParent = gameObject;
//        }
//        else
//        {
//            var ai = newObject.AddComponent<EventTargetAI>();
//            ai.Agent = newObject.GetComponent<SceneObject>();
//            ai.GoParent = gameObject;
//        }
    }
}
