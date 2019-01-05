using System;
using FairyGUI;
using GameFramework.Event;
using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;
using Zoo;

public class StateNormal : FsmState<ProcedureGame>
{
    protected override void OnEnter(IFsm<ProcedureGame> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateNormal OnEnter");
        SubscribeEvent(EvtEnterBuildEdit.EventId, OnEvtEnterBuildEdit);
        SubscribeEvent(EvtEnterDamageEdit.EventId, OnEvtEnterDamageEdit);
        GameEntry.Event.Subscribe(EvtClickScene.EventId, OnEvtClickScene);
        ZooController.Inst.SwipeGesture.onMove.Add(OnSwipeMove);
        ZooController.Inst.HideSceneOptUI();
    }

    protected override void OnLeave(IFsm<ProcedureGame> procedureOwner, bool isShutdown)
    {
        Log.Info("StateNormal OnLeave {0}", isShutdown);
        if (!isShutdown)
        {
            ZooController.Inst.SceneOptController.HideUISceneOpt();
        }
        ZooController.Inst.SwipeGesture.onMove.Remove(OnSwipeMove);

        GameEntry.Event.Unsubscribe(EvtClickScene.EventId, OnEvtClickScene);
        UnsubscribeEvent(EvtEnterBuildEdit.EventId, OnEvtEnterBuildEdit);
        UnsubscribeEvent(EvtEnterDamageEdit.EventId, OnEvtEnterDamageEdit);
        Log.Info("StateNormal OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnEvtClickScene(object sender, GameEventArgs e)
    {
        EvtClickScene evt = e as EvtClickScene;
        Vector2Int grid = MapHelper.ScenePointToGrid(evt.Point);

        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(grid);
        if (data != null)
        {
            if (data.BuildData.BuildType == (int)EZooObjectType.Shop)
            {
                var shopData = GameEntry.Database.Shop.GetShop(data.BuildData.BuildUid);
                GameEntry.UI.OpenUIForm<UI_PanelShop>(shopData);
            }
        }
    }

    private void OnSwipeMove()
    {
        ZooController.Inst.SceneOptController.HideUISceneOpt();
    }

    private void OnEvtEnterBuildEdit(IFsm<ProcedureGame> fsm, object sender, object userData)
    {
        ChangeState<StateBuild>(fsm);
    }

    private void OnEvtEnterDamageEdit(IFsm<ProcedureGame> fsm, object sender, object userData)
    {
        ChangeState<StateEdit>(fsm);
    }
}
