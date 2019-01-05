using UnityEngine;

public class EventSimulateService : TimerService
{
    public EventSimulateService(float timeInterval) : base(timeInterval)
    {
    }

    protected override void Tick()
    {
        int eventId = Random.Range(1, 4);
        TriggerEventCommand.Do(eventId);
    }
}