using System;
using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;

public class StateBuildInEditModeSel : FsmState<StateBuild>
{
    protected bool IsMovingSelObject = false;

    protected override void OnEnter(IFsm<StateBuild> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateBuildInEditModeSel OnEnter");
        SubscribeEvent(StateBuild.EvtClick, OnEvtClickScene);
        SubscribeEvent(StateBuild.EvtRotation, OnEvtRotation);
        SubscribeEvent(StateBuild.EvtRestore, OnEvtRestore);
        SubscribeEvent(StateBuild.EvtChangeBuildMode, OnEvtChangeBuildMode);
        SubscribeEvent(StateBuild.EvtSwipeBegin, OnEvtSwipeBegin);
        SubscribeEvent(StateBuild.EvtSwipeMove, OnEvtSwipeMove);

        GameEntry.TempData.Edit.UpdateSelectBuildInfo(0);
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
        UnsubscribeEvent(StateBuild.EvtSwipeBegin, OnEvtSwipeBegin);
        UnsubscribeEvent(StateBuild.EvtSwipeMove, OnEvtSwipeMove);
        UnsubscribeEvent(StateBuild.EvtChangeBuildMode, OnEvtChangeBuildMode);
        UnsubscribeEvent(StateBuild.EvtRestore, OnEvtRestore);
        UnsubscribeEvent(StateBuild.EvtRotation, OnEvtRotation);
        UnsubscribeEvent(StateBuild.EvtClick, OnEvtClickScene);

        Log.Info("StateBuildInEditModeSel OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
    }

    /// <summary>
    /// 切换建造模式
    /// </summary>
    /// <param name="fsm"></param>
    /// <param name="sender"></param>
    /// <param name="userData"></param>
    private void OnEvtChangeBuildMode(IFsm<StateBuild> fsm, object sender, object userData)
    {
        var evt = userData as EvtChangeTouchState;
        if (!evt.CanSwipeScene)
        {
            ChangeState<StateBuildInBuildMode>(fsm);
        }
    }

    /// <summary>
    /// 点击场景
    /// </summary>
    /// <param name="fsm"></param>
    /// <param name="sender"></param>
    /// <param name="userData"></param>
    private void OnEvtClickScene(IFsm<StateBuild> fsm, object sender, object userData)
    {
        EvtClickScene evt = userData as EvtClickScene;
        Vector2Int grid = MapHelper.ScenePointToGrid(evt.Point);

        // 切换选中对象
        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(grid);
        if (data != null && data.Status == ESceneObjectStatus.Add)
        {
            ZooController.Inst.ShowSceneOptUI(data.ObjectUid);
            return;
        }

        // 转为未选中状态
        ChangeState<StateBuildInEditModeUnSel>(fsm);
    }

    /// <summary>
    /// 旋转对象
    /// </summary>
    /// <param name="fsm"></param>
    /// <param name="sender"></param>
    /// <param name="userData"></param>
    private void OnEvtRotation(IFsm<StateBuild> fsm, object sender, object userData)
    {
        var evt = userData as EvtEditRotation;
        fsm.Owner.RotateEditObject(evt.BuildData, evt.ZooObjectController);
    }

    /// <summary>
    /// 撤销建造
    /// </summary>
    /// <param name="fsm"></param>
    /// <param name="sender"></param>
    /// <param name="userData"></param>
    private void OnEvtRestore(IFsm<StateBuild> fsm, object sender, object userData)
    {
        var evt = userData as EvtEditRestore;
        fsm.Owner.RemoveEditObject(evt.BuildData);
        ZooController.Inst.SceneOptController.HideUISceneOpt();
        ChangeState<StateBuildInEditModeUnSel>(fsm);
    }

    private void OnEvtSwipeBegin(IFsm<StateBuild> fsm, object sender, object userData)
    {
        Vector3 scenePoint = (Vector3)userData;
        Vector2Int grid = MapHelper.ScenePointToGrid(scenePoint);

        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(grid);
        IsMovingSelObject = data.ObjectUid == GameEntry.TempData.Edit.SelectedBuildData.BuildSceneUid;
        ZooController.Inst.EnableSwipe = !IsMovingSelObject;
    }

    private void OnEvtSwipeMove(IFsm<StateBuild> fsm, object sender, object userData)
    {
        if (IsMovingSelObject)
        {
            Vector3 scenePoint = (Vector3)userData;
            Vector2Int grid = MapHelper.ScenePointToGrid(scenePoint);
            fsm.Owner.MoveEditObject(GameEntry.TempData.Edit.SelectedBuildData, grid);
        }
    }
}
