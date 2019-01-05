using FairyGUI;

public static class GListExt
{
    public static void SetData<T>(this GList list, T[] data)
    {
        list.data = data;
        list.numItems = data.Length;
    }

    public static T GetData<T>(this GList list, int index)
    {
        var datas = list.data as T[];
        return datas[index];
    }

    public static T GetSelectedData<T>(this GList list)
    {
        var datas = list.data as T[];
        return datas[list.selectedIndex];
    }
}
