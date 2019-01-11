public partial class TempDataComponent
{
    public EditTempData Edit { get; private set; }
    public ObjectSceneTempData ObjectScene { get; set; }

    private void Start()
    {
        Edit = AddTempData<EditTempData>();
        ObjectScene = AddTempData<ObjectSceneTempData>();
    }

    public void Reset()
    {
        Edit.ClearData();
        ObjectScene.ClearData();
    }
}
