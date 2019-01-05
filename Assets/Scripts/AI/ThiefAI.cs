using DG.Tweening;
using UnityEngine;

public class ThiefAI : SimpleAI
{
    private long AppearStartTime;
    private const long TotalAppearTime = 20;
    private const float DisappearIdleTime = 2f;

    void Start()
    {
        MoveTimePreGrid = 2f;
        Agent = GetComponent<SceneObject>();
        AppearStartTime = TimeUtil.CurrentTime();
        RandAppear();
        RandMove();
    }

    protected override void OnMoveToGridFinish()
    {
        var appearTime = TimeUtil.CurrentTime() - AppearStartTime;
        if (appearTime <= TotalAppearTime)
        {
            CurGrid = MoveTargetGrid;
            RandMove();
        }
        else
        {
            Agent.DoIdle();
            var sequence = DOTween.Sequence();
            sequence.AppendInterval(DisappearIdleTime);
            sequence.AppendCallback(OnDisappear);
        }
    }
}
