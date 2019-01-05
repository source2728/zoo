using Common;
using FairyGUI;

public static class GComponentExt
{
    public static void SetStarLevel(this GComponent com, int starLevel)
    {
        var ui = com as UI_StarLevel;
        ui.m_Level.selectedIndex = starLevel;
    }
}
