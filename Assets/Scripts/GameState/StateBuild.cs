using DataTable;
using FairyGUI;
using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class StateBuild : FsmState<ProcedureGame>
{
    public const int EvtClick = 1;
    public const int EvtSwipeMove = 2;
    public const int EvtRotation = 4;
    public const int EvtRestore = 5;
    public const int EvtChangeBuildMode = 6;
    public const int EvtSwipeBegin = 7;
    public const int EvtSwipeEnd = 8;

    private IFsm<StateBuild> m_Fsm;

    protected override void OnEnter(IFsm<ProcedureGame> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateBuild OnEnter");
        GameEntry.Event.Subscribe(EvtEditRotation.EventId, OnEvtEditRotation);
        GameEntry.Event.Subscribe(EvtEditRestore.EventId, OnEvtEditRestore);
        GameEntry.Event.Subscribe(EvtClickScene.EventId, OnEvtClickScene);
        GameEntry.Event.Subscribe(EvtChangeTouchState.EventId, OnEvtChangeTouchState);
        ZooController.Inst.SwipeGesture.onMove.Add(OnSwipeMove);
        ZooController.Inst.SwipeGesture.onBegin.Add(OnSwipeBegin);
        ZooController.Inst.SwipeGesture.onEnd.Add(OnSwipeEnd);

        m_Fsm = GameEntry.Fsm.CreateFsm(this,
            new StateBuildInEditModeUnSel(),
            new StateBuildInEditModeSel(),
            new StateBuildInBuildMode());
        m_Fsm.Start<StateBuildInBuildMode>();

        procedureOwner.SetData<VarInt>("EditState", ProcedureGame.Editing);
        UIZooView.Inst.UI.m_BtnHand.visible = true;
    }

    protected override void OnUpdate(IFsm<ProcedureGame> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        if (procedureOwner.GetData<VarInt>("EditState") != ProcedureGame.Editing)
        {
            ChangeState<StateNormal>(procedureOwner);
        }
    }

    protected override void OnLeave(IFsm<ProcedureGame> procedureOwner, bool isShutdown)
    {
        var editState = procedureOwner.GetData<VarInt>("EditState");
        if (editState == ProcedureGame.ConfirmEdit)
        {
            GameEntry.TempData.ObjectScene.ConfirmEditToBuilded();
        }
        else if (editState == ProcedureGame.CancelEdit)
        {
            GameEntry.TempData.ObjectScene.CancelEdit();
        }
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());

        if (!isShutdown)
        {
            UIZooView.Inst.UI.m_BtnHand.visible = false;
        }

        GameEntry.Fsm.DestroyFsm(m_Fsm);

        ZooController.Inst.SwipeGesture.onEnd.Remove(OnSwipeEnd);
        ZooController.Inst.SwipeGesture.onBegin.Remove(OnSwipeBegin);
        ZooController.Inst.SwipeGesture.onMove.Remove(OnSwipeMove);
        GameEntry.Event.Unsubscribe(EvtChangeTouchState.EventId, OnEvtChangeTouchState);
        GameEntry.Event.Unsubscribe(EvtClickScene.EventId, OnEvtClickScene);
        GameEntry.Event.Unsubscribe(EvtEditRestore.EventId, OnEvtEditRestore);
        GameEntry.Event.Unsubscribe(EvtEditRotation.EventId, OnEvtEditRotation);
        Log.Info("StateBuild OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
    }

    /// <summary>
    /// 添加新建造物
    /// </summary>
    /// <param name="grid"></param>
    public void AddEditObject(Vector2Int grid)
    {
        if (GameEntry.TempData.Edit.SelectBuildType != EZooObjectType.FenceArea)
        {
            var buildData = GameEntry.TempData.Edit.AddObjectToEditList(grid);
            GameEntry.TempData.Edit.AddToSummaryList(buildData);
            GameEntry.TempData.ObjectScene.AddBuildInfo(buildData, ESceneObjectStatus.Add);
        }
        else
        {
            GameEntry.TempData.Edit.AddToFenceList(grid);

            var buildData = GameEntry.TempData.Edit.AddObjectToEditList(grid);
            GameEntry.TempData.Edit.AddToSummaryList(buildData);
            GameEntry.TempData.ObjectScene.AddBuildInfo(buildData, ESceneObjectStatus.Add);
        }
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());
    }

    public void RemoveEditObject(BuildData buildData)
    {
        GameEntry.TempData.Edit.RemoveFromEditList(buildData);
        GameEntry.TempData.Edit.RemoveFromSummaryList(buildData);
        GameEntry.TempData.ObjectScene.RemoveBuildInfo(buildData);
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());
    }

    public void RotateEditObject(BuildData buildData, ZooObjectController zooObjectController)
    {
        GameEntry.TempData.Edit.UpdateRotationFromEditList(buildData, buildData.Rotate - 90);
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());
    }

    public void MoveEditObject(BuildData buildData, Vector2Int grid)
    {
        GameEntry.TempData.Edit.UpdatePositionFromEditList(buildData, grid);
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());
    }

    /// <summary>
    /// 点击场景，单个建造物品
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnEvtClickScene(object sender, GameEventArgs e)
    {
        m_Fsm.FireEvent(this, EvtClick, e);
    }

    private void OnSwipeBegin(EventContext context)
    {
        Vector3? scenePoint = ZooController.Inst.GetTouchingScenePoint();
        if (scenePoint != null)
        {
            m_Fsm.FireEvent(this, EvtSwipeBegin, scenePoint.Value);
        }
    }

    private void OnSwipeEnd(EventContext context)
    {
        Vector3? scenePoint = ZooController.Inst.GetTouchingScenePoint();
        if (scenePoint != null)
        {
            m_Fsm.FireEvent(this, EvtSwipeEnd, scenePoint.Value);
        }
    }

    /// <summary>
    /// 滑动场景，批量建造物品
    /// </summary>
    /// <param name="context"></param>
    protected void OnSwipeMove(EventContext context)
    {
        Vector3? scenePoint = ZooController.Inst.GetTouchingScenePoint();
        if (scenePoint != null)
        {
            m_Fsm.FireEvent(this, EvtSwipeMove, scenePoint.Value);
        }
    }

    private void OnEvtEditRotation(object sender, GameEventArgs e)
    {
        m_Fsm.FireEvent(this, EvtRotation, e);
    }

    private void OnEvtEditRestore(object sender, GameEventArgs e)
    {
        m_Fsm.FireEvent(this, EvtRestore, e);
    }

    private void OnEvtChangeTouchState(object sender, GameEventArgs e)
    {
        m_Fsm.FireEvent(this, EvtChangeBuildMode, e);
    }
}
