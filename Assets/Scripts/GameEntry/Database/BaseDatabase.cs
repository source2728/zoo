public abstract class BaseDatabase
{
    public bool IsDirty { get; set; }
    public abstract void ClearData();
    public abstract void LoadDataFromJson(string json);
    public abstract void LoadDataFromDefault(DefaultLocalData data);
    public abstract string SaveDataAsJson();
}