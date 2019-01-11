using FairyGUI;
using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class StateEdit : FsmState<ProcedureGame>
{
    public const int EvtClick = 1;
    public const int EvtSwipeMove = 2;
    public const int EvtSwitchBatch = 3;
    public const int EvtLockScene = 4;
    public const int EvtRotation = 5;
    public const int EvtRestore = 6;
    public const int EvtSwipeBegin = 7;

    private IFsm<StateEdit> m_Fsm;

    protected override void OnEnter(IFsm<ProcedureGame> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateEdit OnEnter");
        GameEntry.Event.Subscribe(EvtChangeLookState.EventId, OnEvtChangeLookState);
        GameEntry.Event.Subscribe(EvtChangeTouchState.EventId, OnEvtChangeTouchState);
        GameEntry.Event.Subscribe(EvtClickScene.EventId, OnEvtClickScene);
        GameEntry.Event.Subscribe(EvtEditRotation.EventId, OnEvtEditRotation);
        GameEntry.Event.Subscribe(EvtEditRestore.EventId, OnEvtEditRestore);
        GameEntry.Event.Subscribe(EvtConfirmEdit.EventId, OnEvtConfirmEdit);
        ZooController.Inst.SwipeGesture.onMove.Add(OnSwipeMove);
        ZooController.Inst.SwipeGesture.onBegin.Add(OnSwipeBegin);

        m_Fsm = GameEntry.Fsm.CreateFsm(this,
            new StateEditInBatchModeUnLock(),
            new StateEditInBatchModeLock(),
            new StateEditInUnbatchModeUnSel(),
            new StateEditInUnbatchModeSel());
        m_Fsm.Start<StateEditInUnbatchModeUnSel>();

        procedureOwner.SetData<VarInt>("EditState", ProcedureGame.Editing);
        GameEntry.TempData.ObjectScene.DirtyList.Clear();
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
            GameEntry.TempData.ObjectScene.ConfirmEditToEdited();
        }
        else if (editState == ProcedureGame.CancelEdit)
        {
            GameEntry.TempData.ObjectScene.CancelEdit();
        }
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());

        GameEntry.Fsm.DestroyFsm(m_Fsm);

        ZooController.Inst.SwipeGesture.onBegin.Remove(OnSwipeBegin);
        ZooController.Inst.SwipeGesture.onMove.Remove(OnSwipeMove);
        GameEntry.Event.Unsubscribe(EvtConfirmEdit.EventId, OnEvtConfirmEdit);
        GameEntry.Event.Unsubscribe(EvtEditRestore.EventId, OnEvtEditRestore);
        GameEntry.Event.Unsubscribe(EvtEditRotation.EventId, OnEvtEditRotation);
        GameEntry.Event.Unsubscribe(EvtClickScene.EventId, OnEvtClickScene);
        GameEntry.Event.Unsubscribe(EvtChangeTouchState.EventId, OnEvtChangeTouchState);
        GameEntry.Event.Unsubscribe(EvtChangeLookState.EventId, OnEvtChangeLookState);
        Log.Info("StateEdit OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
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

    /// <summary>
    /// 开始滑动场景
    /// </summary>
    /// <param name="context"></param>
    private void OnSwipeBegin(EventContext context)
    {
        Vector3? scenePoint = ZooController.Inst.GetTouchingScenePoint();
        if (scenePoint != null)
        {
            m_Fsm.FireEvent(this, EvtSwipeBegin, scenePoint.Value);
        }
    }

    /// <summary>
    /// 拆除单元格上的对象
    /// </summary>
    /// <param name="grid"></param>
    public void Damage(Vector2Int grid)
    {
        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(grid);
        if (data != null && data.Status == ESceneObjectStatus.Builded)
        {
            RemoveObject(data.BuildData);
        }
    }

    /// <summary>
    /// 移除原有对象
    /// </summary>
    /// <param name="buildData"></param>
    public void RemoveObject(BuildData buildData)
    {
        GameEntry.TempData.ObjectScene.RemoveBuildInfoByEdit(buildData.BuildSceneUid);
        GameEntry.TempData.Edit.AddObjectToDamageList(buildData);
        GameEntry.TempData.Edit.AddToSummaryList(buildData);
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());
    }

    public void MoveEditObject(BuildData buildData, Vector2Int grid)
    {
        GameEntry.TempData.Edit.AddObjectToEditList(buildData);
        GameEntry.TempData.ObjectScene.UpdateBuildInfoByEdit(buildData.BuildSceneUid, grid);
        GameEntry.TempData.ObjectScene.DirtyList.Add(buildData.BuildSceneUid);
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());
    }

    public void RotateEditObject(BuildData buildData)
    {
        GameEntry.TempData.Edit.AddObjectToEditList(buildData);
        GameEntry.TempData.ObjectScene.UpdateBuildInfoByEdit(buildData.BuildSceneUid, buildData.Rotate - 90);
        GameEntry.TempData.ObjectScene.DirtyList.Add(buildData.BuildSceneUid);
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());
    }

    public void RestoreEditObject(BuildData buildData)
    {
        //        ObjectShowController.RemoveBuildInfo(buildData, true);
        //        m_DamagingObjectList.Remove(buildData);
        //        UIZooView.RefreshEditingObjects(m_DamagingObjectList);
    }

    private void OnEvtChangeLookState(object sender, GameEventArgs e)
    {
        m_Fsm.FireEvent(this, EvtSwitchBatch, e);     
    }

    private void OnEvtChangeTouchState(object sender, GameEventArgs e)
    {
        m_Fsm.FireEvent(this, EvtLockScene, e);
    }

    private void OnEvtEditRotation(object sender, GameEventArgs e)
    {
        m_Fsm.FireEvent(this, EvtRotation, e);
    }

    private void OnEvtEditRestore(object sender, GameEventArgs e)
    {
        m_Fsm.FireEvent(this, EvtRestore, e);
    }

    private void OnEvtConfirmEdit(object sender, GameEventArgs e)
    {
//        EditObjectCommand.Do(new List<BuildData>(m_DamagingObjectList), new List<BuildData>(m_EditingObjectList));
    }
}
