using System;
using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;

public class StateBuildInBuildMode : FsmState<StateBuild>
{
    protected override void OnEnter(IFsm<StateBuild> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateBuildInBuildMode OnEnter");
        SubscribeEvent(StateBuild.EvtClick, OnEvtClickScene);
        SubscribeEvent(StateBuild.EvtSwipeMove, OnEvtSwipeMove);
        SubscribeEvent(StateBuild.EvtChangeBuildMode, OnEvtChangeBuildMode);

        ZooController.Inst.EnableSwipe = false;
        UIZooView.Inst.RefreshWithBuildInBuildMode();
    }

    protected override void OnUpdate(IFsm<StateBuild> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        if (GameEntry.TempData.Edit.SelectBuildId <= 0)
        {
            ZooController.Inst.HideSceneOptUI();
            ChangeState<StateBuildInEditModeUnSel>(procedureOwner);
        }
    }

    protected override void OnLeave(IFsm<StateBuild> procedureOwner, bool isShutdown)
    {
        ZooController.Inst.EnableSwipe = true;
        UnsubscribeEvent(StateBuild.EvtChangeBuildMode, OnEvtChangeBuildMode);
        UnsubscribeEvent(StateBuild.EvtSwipeMove, OnEvtSwipeMove);
        UnsubscribeEvent(StateBuild.EvtClick, OnEvtClickScene);
        Log.Info("StateBuildInBuildMode OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnEvtChangeBuildMode(IFsm<StateBuild> fsm, object sender, object userData)
    {
        var evt = userData as EvtChangeTouchState;
        if (evt.CanSwipeScene)
        {
            ChangeState<StateBuildInEditModeUnSel>(fsm);
        }
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
        fsm.Owner.AddEditObject(grid);
    }

    private void OnEvtSwipeMove(IFsm<StateBuild> fsm, object sender, object userData)
    {
        Vector3 scenePoint = (Vector3)userData;
        Vector2Int grid = MapHelper.ScenePointToGrid(scenePoint);

        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(grid, GameEntry.TempData.Edit.SelectBuildWidth,
            GameEntry.TempData.Edit.SelectBuildHeight);
        if (data == null)
        {
            fsm.Owner.AddEditObject(grid);
        }
    }
}
