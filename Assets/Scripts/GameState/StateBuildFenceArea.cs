using FairyGUI;
using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;

public class StateBuildFenceArea : FsmState<ProcedureGame>
{
    protected override void OnEnter(IFsm<ProcedureGame> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Info("StateBuildFenceArea OnEnter");
        GameEntry.Event.Subscribe(EvtClickScene.EventId, OnEvtClickScene);
        ZooController.Inst.SwipeGesture.onBegin.Add(OnSwipeMove);
        ZooController.Inst.SwipeGesture.onMove.Add(OnSwipeMove);

        procedureOwner.SetData<VarInt>("EditState", ProcedureGame.Editing);
        ZooController.Inst.EnableSwipe = false;
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

        ZooController.Inst.RefreshScene();
        ZooController.Inst.EnableSwipe = true;

        ZooController.Inst.SwipeGesture.onBegin.Remove(OnSwipeMove);
        ZooController.Inst.SwipeGesture.onMove.Remove(OnSwipeMove);
        GameEntry.Event.Unsubscribe(EvtClickScene.EventId, OnEvtClickScene);
        Log.Info("StateBuildFenceArea OnLeave");
        base.OnLeave(procedureOwner, isShutdown);
    }

    /// <summary>
    /// 添加新建造物
    /// </summary>
    /// <param name="grid"></param>
    public void AddEditObject(Vector2Int grid)
    {
        GameEntry.TempData.Edit.AddToFenceList(grid);

        var buildData = GameEntry.TempData.Edit.AddObjectToEditList(grid);
        GameEntry.TempData.Edit.AddToSummaryList(buildData);
        GameEntry.TempData.ObjectScene.AddBuildInfo(buildData, ESceneObjectStatus.Add);
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
        GameEntry.TempData.ObjectScene.DirtyList.Add(buildData.BuildSceneUid);
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
        EvtClickScene evt = e as EvtClickScene;
        Vector2Int grid = MapHelper.ScenePointToGrid(evt.Point);
        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(grid, GameEntry.TempData.Edit.SelectBuildWidth,
            GameEntry.TempData.Edit.SelectBuildHeight);
        if (data == null)
        {
            AddEditObject(grid);
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
            Vector2Int grid = MapHelper.ScenePointToGrid(scenePoint.Value);
            var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(grid, GameEntry.TempData.Edit.SelectBuildWidth,
                GameEntry.TempData.Edit.SelectBuildHeight);
            if (data == null)
            {
                AddEditObject(grid);
            }
        }
    }
}
