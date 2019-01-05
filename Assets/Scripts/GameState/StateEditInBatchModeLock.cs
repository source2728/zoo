using FairyGUI;
using GameFramework.Event;
using GameFramework.Fsm;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class StateEditInBatchModeLock : FsmState<StateEdit>
{
    protected override void OnEnter(IFsm<StateEdit> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateEditInBatchModeLock OnEnter");
        SubscribeEvent(StateEdit.EvtSwitchBatch, OnEvtSwitchBatch);
        SubscribeEvent(StateEdit.EvtLockScene, OnEvtLockScene);
        SubscribeEvent(StateEdit.EvtClick, OnEvtClick);
        SubscribeEvent(StateEdit.EvtSwipeMove, OnEvtSwipeMove);

        ZooController.Inst.EnableSwipe = false;
        UIZooView.Inst.UI.m_BtnHand.visible = true;
    }

    protected override void OnLeave(IFsm<StateEdit> procedureOwner, bool isShutdown)
    {
        if (!isShutdown)
        {
            ZooController.Inst.EnableSwipe = true;
            UIZooView.Inst.UI.m_BtnHand.visible = false;
        }
        
        UnsubscribeEvent(StateEdit.EvtSwipeMove, OnEvtSwipeMove);
        UnsubscribeEvent(StateEdit.EvtClick, OnEvtClick);
        UnsubscribeEvent(StateEdit.EvtLockScene, OnEvtLockScene);
        UnsubscribeEvent(StateEdit.EvtSwitchBatch, OnEvtSwitchBatch);
        Log.Info("StateEditInBatchModeLock OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnEvtSwipeMove(IFsm<StateEdit> fsm, object sender, object userData)
    {
        Vector3 scenePoint = (Vector3)userData;
        Vector2Int grid = MapHelper.ScenePointToGrid(scenePoint);
        fsm.Owner.Damage(grid);
    }

    private void OnEvtClick(IFsm<StateEdit> fsm, object sender, object userData)
    {
        EvtClickScene evt = userData as EvtClickScene;
        Vector2Int grid = MapHelper.ScenePointToGrid(evt.Point);
        fsm.Owner.Damage(grid);
    }

    private void OnEvtLockScene(IFsm<StateEdit> fsm, object sender, object userData)
    {
        EvtChangeTouchState evt = userData as EvtChangeTouchState;
        if (evt.CanSwipeScene)
        {
            ChangeState<StateEditInBatchModeUnLock>(fsm);
        }
    }

    private void OnEvtSwitchBatch(IFsm<StateEdit> fsm, object sender, object userData)
    {
        EvtChangeLookState evt = userData as EvtChangeLookState;
        if (!evt.CanLookEditedObject)
        {
            ChangeState<StateEditInUnbatchModeUnSel>(fsm);
        }
    }
}
