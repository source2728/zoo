using FairyGUI;

public static class GLoaderExt
{
    public static void SetStaffIcon(this GLoader loader, int staffId)
    {
        loader.icon = UIPackage.GetItemURL("Common", "IconStaff_" + staffId);
    }

    public static void SetAnimalIcon(this GLoader loader, int animalId)
    {
        loader.icon = UIPackage.GetItemURL("Common", "IconAnimal_" + animalId);
    }

    public static void SetLandIcon(this GLoader loader, int landId)
    {
        loader.icon = UIPackage.GetItemURL("Common", "IconLand_" + landId);
    }

    public static void SetFenceIcon(this GLoader loader, int fenceId)
    {
        loader.icon = UIPackage.GetItemURL("Common", "IconFence_" + fenceId);
    }

    public static void SetFacilityIcon(this GLoader loader, int facilityId)
    {
        loader.icon = UIPackage.GetItemURL("Common", "IconFacility_" + facilityId);
    }

    public static void SetShopIcon(this GLoader loader, int shopId)
    {
        loader.icon = UIPackage.GetItemURL("Common", "IconShop_" + shopId);
    }

    public static void SetFenceAreaIcon(this GLoader loader, int fenceAreaId)
    {
        loader.icon = UIPackage.GetItemURL("Common", "IconFenceArea_" + fenceAreaId);
    }
}
