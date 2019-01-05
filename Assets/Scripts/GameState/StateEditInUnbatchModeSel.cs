using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;

public class StateEditInUnbatchModeSel : FsmState<StateEdit>
{
    protected bool IsMovingSelObject = false;

    protected override void OnEnter(IFsm<StateEdit> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateEditInUnbatchModeSel OnEnter");
        SubscribeEvent(StateEdit.EvtClick, OnEvtClickScene);
        SubscribeEvent(StateEdit.EvtSwitchBatch, OnEvtSwitchBatch);
        SubscribeEvent(StateEdit.EvtRotation, OnEvtRotation);
        SubscribeEvent(StateEdit.EvtRestore, OnEvtRestore);
        SubscribeEvent(StateEdit.EvtSwipeBegin, OnEvtSwipeBegin);
        SubscribeEvent(StateEdit.EvtSwipeMove, OnEvtSwipeMove);
        ZooController.Inst.EnableSwipe = false;
    }

    protected override void OnLeave(IFsm<StateEdit> procedureOwner, bool isShutdown)
    {
        ZooController.Inst.EnableSwipe = true;
        UnsubscribeEvent(StateEdit.EvtSwipeBegin, OnEvtSwipeBegin);
        UnsubscribeEvent(StateEdit.EvtSwipeMove, OnEvtSwipeMove);
        UnsubscribeEvent(StateEdit.EvtRestore, OnEvtRestore);
        UnsubscribeEvent(StateEdit.EvtRotation, OnEvtRotation);
        UnsubscribeEvent(StateEdit.EvtSwitchBatch, OnEvtSwitchBatch);
        UnsubscribeEvent(StateEdit.EvtClick, OnEvtClickScene);
        Log.Info("StateEditInUnbatchModeSel OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnEvtSwitchBatch(IFsm<StateEdit> fsm, object sender, object userData)
    {
        EvtChangeLookState evt = userData as EvtChangeLookState;
        if (evt.CanLookEditedObject)
        {
            ChangeState<StateEditInBatchModeLock>(fsm);
        }
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
        ChangeState<StateEditInUnbatchModeUnSel>(fsm);
    }

    private void OnEvtRotation(IFsm<StateEdit> fsm, object sender, object userData)
    {
        var evt = userData as EvtEditRotation;
        fsm.Owner.RotateEditObject(evt.BuildData);
    }

    private void OnEvtRestore(IFsm<StateEdit> fsm, object sender, object userData)
    {
        var evt = userData as EvtEditRestore;
        fsm.Owner.RemoveObject(evt.BuildData);
        ChangeState<StateEditInUnbatchModeUnSel>(fsm);
    }

    private void OnEvtSwipeBegin(IFsm<StateEdit> fsm, object sender, object userData)
    {
        Vector3 scenePoint = (Vector3)userData;
        Vector2Int grid = MapHelper.ScenePointToGrid(scenePoint);

        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(grid);
        IsMovingSelObject = data.ObjectUid == GameEntry.TempData.Edit.SelectedBuildData.BuildSceneUid;
        ZooController.Inst.EnableSwipe = !IsMovingSelObject;
    }

    private void OnEvtSwipeMove(IFsm<StateEdit> fsm, object sender, object userData)
    {
        if (IsMovingSelObject)
        {
            Vector3 scenePoint = (Vector3)userData;
            Vector2Int grid = MapHelper.ScenePointToGrid(scenePoint);
            fsm.Owner.MoveEditObject(GameEntry.TempData.Edit.SelectedBuildData, grid);
        }
    }
}
