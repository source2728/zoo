using GameFramework.DataTable;
using System;
using UnityGameFramework.Runtime;

public static class DataTableExtension
{
    private const string DataRowClassPrefixName = "DataTable.DR";
    private static readonly string[] ColumnSplit = new string[] { "\t" };

    public static void LoadDataTable(this DataTableComponent dataTableComponent, string dataTableName, object userData = null)
    {
        if (string.IsNullOrEmpty(dataTableName))
        {
            Log.Warning("Data table name is invalid.");
            return;
        }

        string[] splitNames = dataTableName.Split('_');
        if (splitNames.Length > 2)
        {
            Log.Warning("Data table name is invalid.");
            return;
        }

        string dataRowClassName = DataRowClassPrefixName + splitNames[0];

        Type dataRowType = Type.GetType(dataRowClassName);
        if (dataRowType == null)
        {
            Log.Warning("Can not get data row type with class name '{0}'.", dataRowClassName);
            return;
        }

        string dataTableNameInType = splitNames.Length > 1 ? splitNames[1] : null;
        dataTableComponent.LoadDataTable(dataRowType, dataTableName, dataTableNameInType, AssetUtility.GetDataTableAsset(dataTableName), Constant.AssetPriority.DataTableAsset, userData);
    }

    public static string[] SplitDataRow(string dataRowText)
    {
        return dataRowText.Split(ColumnSplit, StringSplitOptions.None);
    }

    public static T GetDataTableRow<T>(this DataTableComponent dataTableComponent, int id) where T : IDataRow
    {
        IDataTable<T> dt = GameEntry.DataTable.GetDataTable<T>();
        T dr = dt.GetDataRow(id);
        if (dr == null)
        {
            Log.Warning("Can not load id '{0}' from data table '{1}'.", id.ToString(), typeof(T).Name);
            return default(T);
        }

        return dr;
    }
}