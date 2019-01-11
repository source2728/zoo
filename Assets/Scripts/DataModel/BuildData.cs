using DataTable;
using System;
using UnityEngine;

[Serializable]
public class BuildData
{
    public int BuildType;
    public int BuildId;
    public int BuildUid;
    public int BuildSceneUid;
    public float Rotate;
    public RectInt Rect;

    public int Count;

    public int GetCost()
    {
        switch ((EZooObjectType)BuildType)
        {
            case EZooObjectType.FenceArea:
                return GameEntry.DataTable.GetDataTableRow<DRLand>(BuildId).BuildCost;

            case EZooObjectType.Land:
                return GameEntry.DataTable.GetDataTableRow<DRLand>(BuildId).BuildCost;

            case EZooObjectType.Animal:
                return GameEntry.DataTable.GetDataTableRow<DRAnimal>(BuildId).BuyCost;

            case EZooObjectType.Facility:
                return GameEntry.DataTable.GetDataTableRow<DRFacility>(BuildId).BuildCost;

            case EZooObjectType.Shop:
                return GameEntry.DataTable.GetDataTableRow<DRShop>(BuildId).BuildCost;
        }
        return 0;
    }
}
