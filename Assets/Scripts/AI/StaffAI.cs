public class StaffAI : SimpleAI
{
    void Start()
    {
        MoveTimePreGrid = 2f;
        Agent = GetComponent<SceneObject>();
        RandAppear();
        RandMove();
    }

    protected override void OnMoveToGridFinish()
    {
        CurGrid = MoveTargetGrid;
        RandMove();
    }
}
