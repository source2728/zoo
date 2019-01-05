public class ZooSimulateService : TimerService
{
    public ZooSimulateService(float timeInterval) : base(timeInterval)
    {
    }

    protected override void Tick()
    {
        TriggerZooBusinessCommand.Do();
    }
}