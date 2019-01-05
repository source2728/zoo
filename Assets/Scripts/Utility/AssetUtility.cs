using System;

public static class AssetUtility
{
    public static string GetSceneAsset(string assetName)
    {
        return string.Format("Assets/Scenes/{0}.unity", assetName);
    }

    internal static string GetConfigAsset(string configName)
    {
        return string.Format("Assets/Configs/{0}.txt", configName);
    }

    internal static string GetDataTableAsset(string dataTableName)
    {
        return string.Format("Assets/DataTables/{0}.txt", dataTableName);
    }
}
