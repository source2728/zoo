public enum ESceneObjectStatus
{
    Builded,
    Add,
    Remove,
    Edit,
}

public class SceneObjectData
{
    public BuildData BuildData;
    public int ObjectUid;
    public ESceneObjectStatus Status;
}
