public partial class TempDataComponent
{
    public EditTempData Edit { get; private set; }
    public ObjectSceneTempData ObjectScene { get; set; }

    private void Start()
    {
        Edit = AddTempData<EditTempData>();
        ObjectScene = AddTempData<ObjectSceneTempData>();
    }
}
