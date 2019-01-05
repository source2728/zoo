using System;
using FairyGUI;
using GameFramework.Download;
using GameFramework.ObjectPool;
using GameFramework.Resource;
using UnityEngine;

public class FGuiResourceManager : IResourceManager
{
    public string ReadOnlyPath => "";

    public string ReadWritePath => "";

    public ResourceMode ResourceMode => ResourceMode.Package;

    public string CurrentVariant => "";

    public string ApplicableGameVersion => "";

    public int InternalResourceVersion => 0;

    public int AssetCount => 0;

    public int ResourceCount => 0;

    public int ResourceGroupCount => 0;

    public string UpdatePrefixUri { get; set; }
    public int UpdateRetryCount { get; set; }

    public int UpdateWaitingCount => 0;

    public int UpdatingCount => 0;

    public int LoadTotalAgentCount => 0;

    public int LoadFreeAgentCount => 0;

    public int LoadWorkingAgentCount => 0;

    public int LoadWaitingTaskCount => 0;

    public float AssetAutoReleaseInterval { get; set; }
    public int AssetCapacity { get; set; }
    public float AssetExpireTime { get; set; }
    public int AssetPriority { get; set; }
    public float ResourceAutoReleaseInterval { get; set; }
    public int ResourceCapacity { get; set; }
    public float ResourceExpireTime { get; set; }
    public int ResourcePriority { get; set; }

    public event EventHandler<ResourceUpdateStartEventArgs> ResourceUpdateStart;
    public event EventHandler<ResourceUpdateChangedEventArgs> ResourceUpdateChanged;
    public event EventHandler<ResourceUpdateSuccessEventArgs> ResourceUpdateSuccess;
    public event EventHandler<ResourceUpdateFailureEventArgs> ResourceUpdateFailure;

    private LoadAssetCallbacks m_LoadAssetCallbacks;
    public void Init()
    {
        m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadUIFormSuccessCallback, LoadUIFormFailureCallback, LoadUIFormUpdateCallback, LoadUIFormDependencyAssetCallback);
    }

    public void AddLoadResourceAgentHelper(ILoadResourceAgentHelper loadResourceAgentHelper)
    {
        //throw new NotImplementedException();
    }

    public void CheckResources(CheckResourcesCompleteCallback checkResourcesCompleteCallback)
    {
        //throw new NotImplementedException();
    }

    public CheckVersionListResult CheckVersionList(int latestInternalResourceVersion)
    {
        //throw new NotImplementedException();
        return CheckVersionListResult.Updated;
    }

    public float GetResourceGroupProgress(string resourceGroupName)
    {
        //throw new NotImplementedException();
        return 0f;
    }

    public bool GetResourceGroupReady(string resourceGroupName)
    {
        //throw new NotImplementedException();
        return true;
    }

    public int GetResourceGroupReadyResourceCount(string resourceGroupName)
    {
        //throw new NotImplementedException();
        return 0;
    }

    public int GetResourceGroupResourceCount(string resourceGroupName)
    {
        //throw new NotImplementedException();
        return 0;
    }

    public int GetResourceGroupTotalLength(string resourceGroupName)
    {
        //throw new NotImplementedException();
        return 0;
    }

    public int GetResourceGroupTotalReadyLength(string resourceGroupName)
    {
        //throw new NotImplementedException();
        return 0;
    }

    public bool HasAsset(string assetName)
    {
        //throw new NotImplementedException();
        return true;
    }

    public void InitResources(InitResourcesCompleteCallback initResourcesCompleteCallback)
    {
        //throw new NotImplementedException();
    }

    public void LoadAsset(string assetName, LoadAssetCallbacks loadAssetCallbacks)
    {
        //throw new NotImplementedException();
    }

    public void LoadAsset(string assetName, Type assetType, LoadAssetCallbacks loadAssetCallbacks)
    {
        //throw new NotImplementedException();
    }

    public void LoadAsset(string assetName, int priority, LoadAssetCallbacks loadAssetCallbacks)
    {
        //throw new NotImplementedException();
    }

    public void LoadAsset(string assetName, LoadAssetCallbacks loadAssetCallbacks, object userData)
    {
        //throw new NotImplementedException();
    }

    public void LoadAsset(string assetName, Type assetType, int priority, LoadAssetCallbacks loadAssetCallbacks)
    {
        //throw new NotImplementedException();
    }

    public void LoadAsset(string assetName, Type assetType, LoadAssetCallbacks loadAssetCallbacks, object userData)
    {
        //throw new NotImplementedException();
    }

    //public LoadAssetCallbacks loadAssetCallbacks1;
    public void LoadAsset(string assetName, int priority, LoadAssetCallbacks loadAssetCallbacks, object userData)
    {
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Zoo");
        loadAssetCallbacks.LoadAssetSuccessCallback(assetName, assetName, 0, userData);
        //loadAssetCallbacks1 = loadAssetCallbacks;
        //GameEntry.Resource.LoadAsset("Assets/Resources/UI/Zoo_fui.bytes", m_LoadAssetCallbacks, userData);
        //UIPackage.AddPackage();
        //m_ResourceLoader.LoadAsset(assetName, null, priority, loadAssetCallbacks, userData);
    }

    public void LoadAsset(string assetName, Type assetType, int priority, LoadAssetCallbacks loadAssetCallbacks, object userData)
    {
        //throw new NotImplementedException();
    }

    public void LoadScene(string sceneAssetName, LoadSceneCallbacks loadSceneCallbacks)
    {
        //throw new NotImplementedException();
    }

    public void LoadScene(string sceneAssetName, int priority, LoadSceneCallbacks loadSceneCallbacks)
    {
        //throw new NotImplementedException();
    }

    public void LoadScene(string sceneAssetName, LoadSceneCallbacks loadSceneCallbacks, object userData)
    {
        //throw new NotImplementedException();
    }

    public void LoadScene(string sceneAssetName, int priority, LoadSceneCallbacks loadSceneCallbacks, object userData)
    {
        //throw new NotImplementedException();
    }

    public void SetCurrentVariant(string currentVariant)
    {
        //throw new NotImplementedException();
    }

    public void SetDecryptResourceCallback(DecryptResourceCallback decryptResourceCallback)
    {
        //throw new NotImplementedException();
    }

    public void SetDownloadManager(IDownloadManager downloadManager)
    {
        //throw new NotImplementedException();
    }

    public void SetObjectPoolManager(IObjectPoolManager objectPoolManager)
    {
        //throw new NotImplementedException();
    }

    public void SetReadOnlyPath(string readOnlyPath)
    {
        //throw new NotImplementedException();
    }

    public void SetReadWritePath(string readWritePath)
    {
        //throw new NotImplementedException();
    }

    public void SetResourceHelper(IResourceHelper resourceHelper)
    {
        //throw new NotImplementedException();
    }

    public void SetResourceMode(ResourceMode resourceMode)
    {
        //throw new NotImplementedException();
    }

    public void UnloadAsset(object asset)
    {
        //throw new NotImplementedException();
    }

    public void UnloadScene(string sceneAssetName, UnloadSceneCallbacks unloadSceneCallbacks)
    {
        //throw new NotImplementedException();
    }

    public void UnloadScene(string sceneAssetName, UnloadSceneCallbacks unloadSceneCallbacks, object userData)
    {
        //throw new NotImplementedException();
    }

    public void UpdateResources(UpdateResourcesCompleteCallback updateResourcesCompleteCallback)
    {
        //throw new NotImplementedException();
    }

    public void UpdateVersionList(int versionListLength, int versionListHashCode, int versionListZipLength, int versionListZipHashCode, UpdateVersionListCallbacks updateVersionListCallbacks)
    {
        //throw new NotImplementedException();
    }

    public void LoadUIFormSuccessCallback(string uiFormAssetName, object uiFormAsset, float duration, object userData)
    {
        //TextAsset textAsset = uiFormAsset as TextAsset;
        //UIPackage.AddPackage(textAsset.bytes, "", new UIPackage.LoadResource(async (string name, string extension, ZooEventId type, out DestroyMethod destroyMethod) => {
        //    destroyMethod = new DestroyMethod();
        //    await 
        //};));
        //loadAssetCallbacks1.LoadAssetSuccessCallback(uiFormAssetName, uiFormAsset, duration, userData);

        //OpenUIFormInfo openUIFormInfo = (OpenUIFormInfo)userData;
        //if (openUIFormInfo == null)
        //{
        //    throw new GameFrameworkException("Open UI form info is invalid.");
        //}

        //m_UIFormsBeingLoaded.Remove(openUIFormInfo.SerialId);
        //m_UIFormAssetNamesBeingLoaded.Remove(uiFormAssetName);
        //if (m_UIFormsToReleaseOnLoad.Contains(openUIFormInfo.SerialId))
        //{
        //    GameFrameworkLog.Debug("Release UI form '{0}' on loading success.", openUIFormInfo.SerialId.ToString());
        //    m_UIFormsToReleaseOnLoad.Remove(openUIFormInfo.SerialId);
        //    m_UIFormHelper.ReleaseUIForm(uiFormAsset, null);
        //    return;
        //}

        //UIFormInstanceObject uiFormInstanceObject = new UIFormInstanceObject(uiFormAssetName, uiFormAsset, m_UIFormHelper.InstantiateUIForm(uiFormAsset), m_UIFormHelper);
        //m_InstancePool.Register(uiFormInstanceObject, true);

        //InternalOpenUIForm(openUIFormInfo.SerialId, uiFormAssetName, openUIFormInfo.UIGroup, uiFormInstanceObject.Target, openUIFormInfo.PauseCoveredUIForm, true, duration, openUIFormInfo.UserData);
    }

    private void LoadUIFormFailureCallback(string uiFormAssetName, LoadResourceStatus status, string errorMessage, object userData)
    {
        //OpenUIFormInfo openUIFormInfo = (OpenUIFormInfo)userData;
        //if (openUIFormInfo == null)
        //{
        //    throw new GameFrameworkException("Open UI form info is invalid.");
        //}

        //m_UIFormsBeingLoaded.Remove(openUIFormInfo.SerialId);
        //m_UIFormAssetNamesBeingLoaded.Remove(uiFormAssetName);
        //m_UIFormsToReleaseOnLoad.Remove(openUIFormInfo.SerialId);
        //string appendErrorMessage = Utility.Text.Format("Load UI form failure, asset name '{0}', status '{1}', error message '{2}'.", uiFormAssetName, status.ToString(), errorMessage);
        //if (m_OpenUIFormFailureEventHandler != null)
        //{
        //    m_OpenUIFormFailureEventHandler(this, new OpenUIFormFailureEventArgs(openUIFormInfo.SerialId, uiFormAssetName, openUIFormInfo.UIGroup.Name, openUIFormInfo.PauseCoveredUIForm, appendErrorMessage, openUIFormInfo.UserData));
        //    return;
        //}

        //throw new GameFrameworkException(appendErrorMessage);
    }

    private void LoadUIFormUpdateCallback(string uiFormAssetName, float progress, object userData)
    {
        //OpenUIFormInfo openUIFormInfo = (OpenUIFormInfo)userData;
        //if (openUIFormInfo == null)
        //{
        //    throw new GameFrameworkException("Open UI form info is invalid.");
        //}

        //if (m_OpenUIFormUpdateEventHandler != null)
        //{
        //    m_OpenUIFormUpdateEventHandler(this, new OpenUIFormUpdateEventArgs(openUIFormInfo.SerialId, uiFormAssetName, openUIFormInfo.UIGroup.Name, openUIFormInfo.PauseCoveredUIForm, progress, openUIFormInfo.UserData));
        //}
    }

    private void LoadUIFormDependencyAssetCallback(string uiFormAssetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
    {
        //OpenUIFormInfo openUIFormInfo = (OpenUIFormInfo)userData;
        //if (openUIFormInfo == null)
        //{
        //    throw new GameFrameworkException("Open UI form info is invalid.");
        //}

        //if (m_OpenUIFormDependencyAssetEventHandler != null)
        //{
        //    m_OpenUIFormDependencyAssetEventHandler(this, new OpenUIFormDependencyAssetEventArgs(openUIFormInfo.SerialId, uiFormAssetName, openUIFormInfo.UIGroup.Name, openUIFormInfo.PauseCoveredUIForm, dependencyAssetName, loadedCount, totalCount, openUIFormInfo.UserData));
        //}
    }
}
