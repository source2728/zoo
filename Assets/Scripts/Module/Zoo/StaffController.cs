using DataTable;
using GameFramework.Resource;
using UnityEngine;

public class StaffController : MonoBehaviour
{
    public int StaffId;

    void Start()
    {
        var m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadUIFormSuccessCallback);
        var data = GameEntry.Database.Staff.GetStaffData(StaffId);
        var deploy = GameEntry.DataTable.GetDataTableRow<DRStaff>(data.Id);
        GameEntry.Resource.LoadAsset(deploy.ModulePath, m_LoadAssetCallbacks);
    }

    private void LoadUIFormSuccessCallback(string assetName, object asset, float duration, object userData)
    {
        var newObject = Instantiate(asset as GameObject);
        newObject.transform.SetParent(transform);
        newObject.transform.localPosition = Vector3.zero;
        newObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

        var ai = newObject.AddComponent<StaffAI>();
        ai.Agent = newObject.GetComponent<SceneObject>();
        ai.GoParent = gameObject;
    }
}
