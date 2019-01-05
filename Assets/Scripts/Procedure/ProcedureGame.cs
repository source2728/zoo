using System;
using DataTable;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using Zoo;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class ProcedureGame : ProcedureBase
{
    public const int Editing = 0;
    public const int CancelEdit = 1;
    public const int ConfirmEdit = 2;

    protected int m_ChangeStateType = 0;
    protected IFsm<ProcedureGame> m_Fsm;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        GameEntry.Event.Subscribe(EvtTranToVisit.EventId, OnEvtTranToVisit);
        GameEntry.Event.Subscribe(EvtFinishEdit.EventId, OnEvtFinishEdit);
        GameEntry.Event.Subscribe(EvtMainUIShown.EventId, OnEvtMainUIShown);
        GameEntry.Event.Subscribe(EvtEnterBuildEdit.EventId, OnEvtEnterBuildEdit);
        GameEntry.Event.Subscribe(EvtEnterDamageEdit.EventId, OnEvtEnterDamageEdit);

        m_ChangeStateType = 0;
        Log.Info("ProcedureGame OnEnter");

        GameEntry.Database.LoadGame();

        m_Fsm = GameEntry.Fsm.CreateFsm(this,
            new StateNormal(),
            new StateBuild(),
            new StateEdit());

        GameEntry.UI.OpenUIForm<UI_ZooView>(this);

        ZooController.Inst.StartGame();
    }

    private void LoadUIFormSuccessCallback(string assetName, object asset, float duration, object userData)
    {
        var newObject = UnityEngine.Object.Instantiate(asset as GameObject);
        newObject.SetActive(false);
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        GameEntry.Fsm.DestroyFsm(m_Fsm);

        GameEntry.Event.Unsubscribe(EvtEnterBuildEdit.EventId, OnEvtEnterBuildEdit);
        GameEntry.Event.Unsubscribe(EvtEnterDamageEdit.EventId, OnEvtEnterDamageEdit);
        GameEntry.Event.Unsubscribe(EvtMainUIShown.EventId, OnEvtMainUIShown);
        GameEntry.Event.Unsubscribe(EvtFinishEdit.EventId, OnEvtFinishEdit);
        GameEntry.Event.Unsubscribe(EvtTranToVisit.EventId, OnEvtTranToVisit);
        base.OnLeave(procedureOwner, isShutdown);
        Log.Info("ProcedureGame OnLeave {0}", isShutdown);
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (m_ChangeStateType == 1)
        {
            ChangeState<ProcedureVisit>(procedureOwner);
        }
    }

    private void OnEvtTranToVisit(object sender, GameEventArgs e)
    {
        m_ChangeStateType = 1;
    }

    private void OnEvtFinishEdit(object sender, GameEventArgs e)
    {
        var evt = e as EvtFinishEdit;
        m_Fsm.SetData<VarInt>("EditState", evt.IsConfirmEdit ? ConfirmEdit : CancelEdit);
    }

    private void OnEvtMainUIShown(object sender, GameEventArgs e)
    {
        m_Fsm.Start<StateNormal>();
    }

    private void OnEvtEnterBuildEdit(object sender, GameEventArgs e)
    {
        m_Fsm.FireEvent(this, e.Id, e);
    }

    private void OnEvtEnterDamageEdit(object sender, GameEventArgs e)
    {
        m_Fsm.FireEvent(this, e.Id, e);
    }
}