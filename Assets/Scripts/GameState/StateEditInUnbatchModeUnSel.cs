using FairyGUI;
using GameFramework.Event;
using GameFramework.Fsm;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class StateEditInUnbatchModeUnSel : FsmState<StateEdit>
{
    protected override void OnEnter(IFsm<StateEdit> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateEditInUnbatchModeUnSel OnEnter");
        SubscribeEvent(StateEdit.EvtClick, OnEvtClickScene);
        SubscribeEvent(StateEdit.EvtSwitchBatch, OnEvtSwitchBatch);

        ZooController.Inst.SceneOptController.HideUISceneOpt();
    }

    protected override void OnLeave(IFsm<StateEdit> procedureOwner, bool isShutdown)
    {
        UnsubscribeEvent(StateEdit.EvtClick, OnEvtClickScene);
        UnsubscribeEvent(StateEdit.EvtSwitchBatch, OnEvtSwitchBatch);
        Log.Info("StateEditInUnbatchModeUnSel OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnEvtClickScene(IFsm<StateEdit> fsm, object sender, object userData)
    {
        EvtClickScene evt = userData as EvtClickScene;
        Vector2Int grid = MapHelper.ScenePointToGrid(evt.Point);

        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(grid);
        if (data != null)
        {
            if (data.Status != ESceneObjectStatus.Remove)
            {
                ZooController.Inst.ShowSceneOptUI(data.ObjectUid);
                ChangeState<StateEditInUnbatchModeSel>(fsm);
            }
            return;
        }
    }

    private void OnEvtSwitchBatch(IFsm<StateEdit> fsm, object sender, object userData)
    {
        EvtChangeLookState evt = userData as EvtChangeLookState;
        if (evt.CanLookEditedObject)
        {
            ChangeState<StateEditInBatchModeLock>(fsm);
        }
    }
}
