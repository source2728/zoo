using GameFramework.Event;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class ProcedureVisit : ProcedureBase
{
    protected int ChangeStateType = 0;

    protected override void OnInit(ProcedureOwner procedureOwner)
    {
        base.OnInit(procedureOwner);
        Log.Info("ProcedureVisit OnInit");
    }

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        GameEntry.Event.Subscribe(EvtTranToVisit.EventId, OnEvtTranToVisit);
        ChangeStateType = 0;
        Log.Info("ProcedureVisit OnEnter");
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        GameEntry.Event.Unsubscribe(EvtTranToVisit.EventId, OnEvtTranToVisit);
        base.OnLeave(procedureOwner, isShutdown);
        Log.Info("ProcedureVisit OnLeave");
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (ChangeStateType == 1)
        {
            ChangeState<ProcedureGame>(procedureOwner);
        }
    }

    private void OnEvtTranToVisit(object sender, GameEventArgs e)
    {
        ChangeStateType = 1;
    }
}