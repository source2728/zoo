using GameFramework;
using UnityEngine;
using UnityGameFramework.Editor;
using UnityGameFramework.Editor.AssetBundleTools;

public static class GameFrameworkConfigs
{
    [BuildSettingsConfigPath]
    public static string BuildSettingsConfig = Utility.Path.GetCombinePath(Application.dataPath, "Configs/BuildSettings.xml");

    [AssetBundleBuilderConfigPath]
    public static string AssetBundleBuilderConfig = Utility.Path.GetCombinePath(Application.dataPath, "Configs/AssetBundleBuilder.xml");

    [AssetBundleEditorConfigPath]
    public static string AssetBundleEditorConfig = Utility.Path.GetCombinePath(Application.dataPath, "Configs/AssetBundleEditor.xml");

    [AssetBundleCollectionConfigPath]
    public static string AssetBundleCollectionConfig = Utility.Path.GetCombinePath(Application.dataPath, "Configs/AssetBundleCollection.xml");
}