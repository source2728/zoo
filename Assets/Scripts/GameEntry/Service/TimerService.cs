using UnityEngine;

public class TimerService : BaseService
{
    protected float TimeInterval;
    protected float TimeLeft;

    public TimerService(float timeInterval)
    {
        TimeInterval = timeInterval;
    }

    public override void Start()
    {
        TimeLeft = TimeInterval;
    }

    public override void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0)
        {
            TimeLeft = TimeInterval;
            Tick();
        }
    }

    protected virtual void Tick()
    {

    }
}