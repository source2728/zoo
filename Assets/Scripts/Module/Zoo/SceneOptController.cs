using FairyGUI;
using GameFramework;
using GameFramework.Resource;
using UnityEngine;
using Zoo;

public class SceneOptController
{
    public UIPanel UISceneOpt { get; set; }
    protected BuildData BuildData;
    protected ZooObjectController ZooObjectController;

    public void Init()
    {
        var m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadUIFormSuccessCallback);
        GameEntry.Resource.LoadAsset("Assets/SceneOpt.prefab", m_LoadAssetCallbacks);
    }

    private void LoadUIFormSuccessCallback(string assetName, object asset, float duration, object userData)
    {
        var newObject = UnityEngine.Object.Instantiate(asset as GameObject);
        newObject.SetActive(false);

        UISceneOpt = newObject.GetComponent<UIPanel>();
        var sceneOpt = UISceneOpt.ui as UI_SceneOpt;
        sceneOpt.m_BtnRotation.onClick.Set(OnOptRotation);
        sceneOpt.m_BtnRestore.onClick.Set(OnOptRestore);
    }

    public void ShowUISceneOpt(BuildData buildData, ZooObjectController zooObjectController)
    {
        BuildData = buildData;
        ZooObjectController = zooObjectController;
        UISceneOpt.transform.SetParent(zooObjectController.transform, false);
        UISceneOpt.gameObject.SetActive(true);
        UISceneOpt.enabled = true;
    }

    public void HideUISceneOpt()
    {
        if (UISceneOpt != null)
        {
            UISceneOpt.transform.SetParent(null, false);
            UISceneOpt.gameObject.SetActive(false);
        }
    }

    private void OnOptRotation()
    {
        var evt = ReferencePool.Acquire<EvtEditRotation>();
        evt.BuildData = BuildData;
        evt.ZooObjectController = ZooObjectController;
        GameEntry.Event.Fire(this, evt);
    }

    private void OnOptRestore()
    {
        var evt = ReferencePool.Acquire<EvtEditRestore>();
        evt.BuildData = BuildData;
        evt.ZooObjectController = ZooObjectController;
        GameEntry.Event.Fire(this, evt);
    }
}
