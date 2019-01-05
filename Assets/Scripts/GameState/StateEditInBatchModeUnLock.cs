using FairyGUI;
using GameFramework.Event;
using GameFramework.Fsm;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class StateEditInBatchModeUnLock : FsmState<StateEdit>
{
    protected override void OnEnter(IFsm<StateEdit> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateEditInBatchModeUnLock OnEnter");
        SubscribeEvent(StateEdit.EvtSwitchBatch, OnEvtSwitchBatch);
        SubscribeEvent(StateEdit.EvtLockScene, OnEvtLockScene);
        UIZooView.Inst.UI.m_BtnHand.visible = true;
    }

    protected override void OnLeave(IFsm<StateEdit> procedureOwner, bool isShutdown)
    {
        UIZooView.Inst.UI.m_BtnHand.visible = false;
        UnsubscribeEvent(StateEdit.EvtLockScene, OnEvtLockScene);
        UnsubscribeEvent(StateEdit.EvtSwitchBatch, OnEvtSwitchBatch);
        Log.Info("StateEditInBatchModeUnLock OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnEvtLockScene(IFsm<StateEdit> fsm, object sender, object userData)
    {
        EvtChangeTouchState evt = userData as EvtChangeTouchState;
        if (!evt.CanSwipeScene)
        {
            ChangeState<StateEditInBatchModeLock>(fsm);
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
