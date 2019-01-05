public partial class ServiceComponent
{
    private void AddCustomServices()
    {
        AddService(new EventSimulateService(30));
        AddService(new ShopSimulateService(20));
        AddService(new ZooSimulateService(10));
    }
}
