public class ShopSimulateService : TimerService
{
    public ShopSimulateService(float timeInterval) : base(timeInterval)
    {
    }

    protected override void Tick()
    {
        TriggerShopBusinessCommand.Do();
    }
}