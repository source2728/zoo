using DataTable;
using FairyGUI;
using GameFramework.Event;
using GameFramework.Fsm;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class StateBuildInEditModeUnSel : FsmState<StateBuild>
{
    protected override void OnEnter(IFsm<StateBuild> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateBuildInEditModeUnSel OnEnter");
        SubscribeEvent(StateBuild.EvtClick, OnEvtClickScene);
        SubscribeEvent(StateBuild.EvtChangeBuildMode, OnEvtChangeBuildMode);

        GameEntry.TempData.Edit.UpdateSelectBuildInfo(0);
        ZooController.Inst.HideSceneOptUI();
        UIZooView.Inst.RefreshWithBuildInEditMode();
    }

    protected override void OnUpdate(IFsm<StateBuild> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        if (GameEntry.TempData.Edit.SelectBuildId > 0)
        {
            ZooController.Inst.HideSceneOptUI();
            ChangeState<StateBuildInBuildMode>(procedureOwner);
        }
    }

    protected override void OnLeave(IFsm<StateBuild> procedureOwner, bool isShutdown)
    {
        UnsubscribeEvent(StateBuild.EvtChangeBuildMode, OnEvtChangeBuildMode);
        UnsubscribeEvent(StateBuild.EvtClick, OnEvtClickScene);
        Log.Info("StateBuildInEditModeUnSel OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnEvtClickScene(IFsm<StateBuild> fsm, object sender, object userData)
    {
        EvtClickScene evt = userData as EvtClickScene;
        Vector2Int grid = MapHelper.ScenePointToGrid(evt.Point);

        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(grid);
        if (data != null)
        {
            if (data.Status == ESceneObjectStatus.Add)
            {
                ZooController.Inst.ShowSceneOptUI(data.ObjectUid);
                ChangeState<StateBuildInEditModeSel>(fsm);
            }
            return;
        }
    }

    private void OnEvtChangeBuildMode(IFsm<StateBuild> fsm, object sender, object userData)
    {
        var evt = userData as EvtChangeTouchState;
        if (!evt.CanSwipeScene)
        {
            ChangeState<StateBuildInBuildMode>(fsm);
        }
    }
}
