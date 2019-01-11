using System.Collections.Generic;
using FairyGUI;
using GameFramework;
using GameFramework.Event;
using UnityEngine;

public class ZooController : MonoBehaviour
{
    public static ZooController Inst;
    protected readonly Quaternion SceneRotate = Quaternion.Euler(0, -45, 0);
    protected readonly float GragRatio = 60;   //200
    protected readonly float InertiaingRatio = 1250;

    public Camera m_Camera;
    public UIPanel m_GesturePanel;
    public GameObject m_CameraCenter;
    public GameObject m_BuildingList;
    public GameObject m_TerrainList;

    public LongPressGesture LongPressGesture { get; private set; }
    public SwipeGesture SwipeGesture { get; private set; }
    public PinchGesture PinchGesture { get; private set; }
    public RotationGesture RotationGesture { get; private set; }

    public bool EnableLongPress = true;
    public bool EnableSwipe = true;
    public bool EnablePinch = true;
    public bool EnableRotation = true;

    public SceneOptController SceneOptController;

    public Dictionary<int, ZooObjectController> m_BuildingGoMap = new Dictionary<int, ZooObjectController>();
    public Dictionary<int, StaffController> StaffGoMap = new Dictionary<int, StaffController>();
    public Dictionary<int, Dictionary<int, AnimalController>> AnimalGoMap = new Dictionary<int, Dictionary<int, AnimalController>>();
    public int GoVisitorCount = 0;

    public GameObject GoCharactorList;

    public Material[] BuildingMaterials;
    public GameObject[] GoAreaShadows;
    public UIPanel[] m_BtnUnlockAreas;

    void Start()
    {
        Inst = this;
        GameEntry.Event.Subscribe(EvtDataUpdated.EventId, OnEvtDataUpdated);
        GameEntry.Event.Subscribe(EvtTempDataUpdated.EventId, OnEvtTempDataUpdated);
        GameEntry.Event.Subscribe(EvtEventTriggered.EventId, OnEvtEventTriggered);
        GameEntry.Event.Subscribe(EvtZooBusinessTriggered.EventId, OnEvtZooBusinessTriggered);
        GameEntry.Event.Subscribe(EvtDataReseted.EventId, OnEvtDataReseted);

        GObject holder = m_GesturePanel.ui.GetChild("holder");
        holder.onClick.Add(OnClick);

        for (int i = 0; i < m_BtnUnlockAreas.Length; i++)
        {
            UIPanel btnPanel = m_BtnUnlockAreas[i];
            btnPanel.ui.data = i + 1;
            btnPanel.ui.onClick.Set(OnClickUnlockArea);
        }

        LongPressGesture = new LongPressGesture(holder);
        LongPressGesture.once = false;
        LongPressGesture.onAction.Add(OnLongPress);

        SwipeGesture = new SwipeGesture(holder);
        SwipeGesture.onBegin.Add(OnSwipeBegin);
        SwipeGesture.onMove.Add(OnSwipeMove);
        SwipeGesture.onEnd.Add(OnSwipeEnd);

        PinchGesture = new PinchGesture(holder);
        PinchGesture.onAction.Add(OnPinch);

        RotationGesture = new RotationGesture(holder);
        RotationGesture.onAction.Add(OnRotate);
    }

    private void OnEvtDataReseted(object sender, GameEventArgs e)
    {
        m_BuildingGoMap.Clear();
        StaffGoMap.Clear();
        AnimalGoMap.Clear();
        GoVisitorCount = 0;

        for (int i = GoCharactorList.transform.childCount - 1; i >= 0; i--)
        {
            var child = GoCharactorList.transform.GetChild(i);
            Destroy(child.gameObject);
        }

        for (int i = m_BuildingList.transform.childCount - 1; i >= 0; i--)
        {
            var child = m_BuildingList.transform.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    private void OnClickUnlockArea(EventContext context)
    {
        var btn = context.sender as GComponent;
        UnlockZooAreaCommand.Do((int)btn.data);
    }

    private void OnEvtZooBusinessTriggered(object sender, GameEventArgs e)
    {
        AddVisitorObject(4);
    }

    private void OnEvtDataUpdated(object sender, GameEventArgs e)
    {
        foreach (var staffData in GameEntry.Database.Staff.StaffList)
        {
            AddStaffObject(staffData.Uid);
        }

        foreach (var data in GameEntry.Database.FenceArea.FenceAreaList)
        {
            RefreshAnimalObject(data);
        }

        foreach (var go in GoAreaShadows)
        {
            go.SetActive(true);
        }
        foreach (var panel in m_BtnUnlockAreas)
        {
            panel.ui.visible = true;
        }
        foreach (var id in GameEntry.Database.Zoo.ZooData.UnlockAreaIds)
        {
            GoAreaShadows[id - 1].SetActive(false);
            m_BtnUnlockAreas[id - 1].ui.visible = false;
        }
    }

    private void OnEvtEventTriggered(object sender, GameEventArgs e)
    {
        var evt = e as EvtEventTriggered;
        AddEventObject(evt.ZooEventId);
    }

    private void AddEventObject(int eventId)
    {
        var d = new GameObject("Event");
        d.transform.SetParent(GoCharactorList.transform, true);
        var controller = d.AddComponent<EventObjectController>();
        controller.EventId = eventId;
    }

    private void AddStaffObject(int staffId)
    {
        if (!StaffGoMap.ContainsKey(staffId))
        {
            var d = new GameObject("Staff");
            d.transform.SetParent(GoCharactorList.transform, true);
            var controller = d.AddComponent<StaffController>();
            controller.StaffId = staffId;
            StaffGoMap.Add(staffId, controller);
        }
    }

    private void AddVisitorObject(int count)
    {
        int totalCount = Mathf.Min(5, GoVisitorCount + count);
        for (int i = GoVisitorCount; i < totalCount; i++)
        {
            var d = new GameObject("Visitor");
            d.transform.SetParent(GoCharactorList.transform, true);
            var controller = d.AddComponent<VisitorController>();
        }

        GoVisitorCount = totalCount;
    }

    private void RefreshAnimalObject(FenceAreaData data)
    {
        if (data.AnimalCounts.Count <= 0)
            return;

        Dictionary<int, AnimalController> map;
        if (!AnimalGoMap.TryGetValue(data.Uid, out map))
        {
            map = new Dictionary<int, AnimalController>();
            AnimalGoMap.Add(data.Uid, map);
        }

        foreach (var countData in data.AnimalCounts)
        {
            if (!map.ContainsKey(countData.x))
            {
                var d = new GameObject("Animal");
                d.transform.SetParent(GoCharactorList.transform, true);
                var controller = d.AddComponent<AnimalController>();
                controller.AnimalId = countData.x;
                controller.FenceAreaId = data.Uid;
                map.Add(countData.x, controller);
            }
        }        
    }

    private void OnEvtTempDataUpdated(object sender, GameEventArgs e)
    {
        var list = GameEntry.TempData.ObjectScene.DirtyList;
        foreach (var uid in list)
        {
            var sceneObjectData = GameEntry.TempData.ObjectScene.GetSceneObjectData(uid);
            if (sceneObjectData != null)
            {
                ZooObjectController zooObjectController;
                if (!m_BuildingGoMap.TryGetValue(uid, out zooObjectController))
                {
                    // 创建场景对象
                    var newObject = new GameObject("Shop");
                    newObject.transform.SetParent(m_BuildingList.transform, true);

                    // 添加对象控制器
                    var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(uid);
                    zooObjectController = newObject.GetOrAddComponent<ZooObjectController>();
                    zooObjectController.BuildData = data.BuildData;
                    m_BuildingGoMap.Add(uid, zooObjectController);
                }

                if (sceneObjectData.Status == ESceneObjectStatus.Remove)
                {
                    zooObjectController.gameObject.SetActive(false);
                }
                else
                {
                    zooObjectController.gameObject.SetActive(true);
                    zooObjectController.UpdatePosition();
                    zooObjectController.UpdateRotation();
                }

                if (sceneObjectData.Status == ESceneObjectStatus.Builded)
                {
                    zooObjectController.UpdateMaterial(BuildingMaterials[0]);
                }
                else
                {
                    zooObjectController.UpdateMaterial(BuildingMaterials[1]);
                }
            }
            else
            {
                ZooObjectController zooObjectController;
                if (m_BuildingGoMap.TryGetValue(uid, out zooObjectController))
                {
                    Destroy(zooObjectController.gameObject);
                }
            }
        }
        GameEntry.TempData.ObjectScene.DirtyList.Clear();
    }

    public void StartGame()
    {
        SceneOptController = new SceneOptController();
        SceneOptController.Init();
        RefreshScene();
        m_CameraCenter.transform.position = new Vector3(10.4f, 0, 6.3f);
    }

    public void RefreshScene()
    {
        foreach (var shop in GameEntry.Database.Shop.ShopList)
        {
            GameEntry.TempData.ObjectScene.AddShopInfo(shop);
        }
        foreach (var data in GameEntry.Database.FenceArea.FenceAreaList)
        {
            GameEntry.TempData.ObjectScene.AddFenceArea(data);
        }
        foreach (var data in GameEntry.Database.Facility.FacilityList)
        {
            GameEntry.TempData.ObjectScene.AddFacilityInfo(data);
        }
        foreach (var data in GameEntry.Database.Land.LandList)
        {
            GameEntry.TempData.ObjectScene.AddLandInfo(data);
        }
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());
    }

    public Vector3? GetTouchingScenePoint()
    {
        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 10000, LayerMask.GetMask("Ground")))
        {
            return hitInfo.point;
        }
        return null;
    }

    private void OnClick(EventContext context)
    {
        Vector3? scenePoint = GetTouchingScenePoint();
        if (scenePoint != null)
        {
            var evtClickScene = ReferencePool.Acquire<EvtClickScene>();
            evtClickScene.Point = scenePoint.Value;
            GameEntry.Event.Fire(this, evtClickScene);
        }
    }

    private void OnLongPress(EventContext context)
    {
        if (EnableLongPress)
        {
            Debug.Log("OnLongPress");
        }
    }

    private void OnRotate(EventContext context)
    {
        if (!EnableRotation)
        {
            RotationGesture gesture = (RotationGesture)context.sender;
            m_CameraCenter.transform.Rotate(Vector3.down, -gesture.delta, Space.World);
        }
    }

    private void OnPinch(EventContext context)
    {
        if (EnablePinch)
        {
            PinchGesture gesture = (PinchGesture)context.sender;
            var value = m_Camera.orthographicSize - gesture.delta * 2;
            value = Mathf.Clamp(value, 3, 8);
            m_Camera.orthographicSize = value;
        }
    }

    public void MoveToGrid(Vector2Int grid)
    {
        Vector3 position = MapHelper.GridToScenePoint(grid);
        m_CameraCenter.transform.position = position;
    }

    private void OnSwipeBegin(EventContext context)
    {
        if (EnableSwipe)
        {
            SwipeGesture gesture = (SwipeGesture)context.sender;
        }
    }

    private void OnSwipeMove(EventContext context)
    {
        if (EnableSwipe)
        {
            SwipeGesture gesture = (SwipeGesture)context.sender;
            Vector3 offset = new Vector3(gesture.delta.x, 0, -gesture.delta.y);
            var moveOffset = SceneRotate * offset / GragRatio; moveOffset.y = 0;

            Vector3 position = m_CameraCenter.transform.position - moveOffset;
            position.x = Mathf.Clamp(position.x, 0.8f, 38.5f);
            position.z = Mathf.Clamp(position.z, 0, 40f);
            m_CameraCenter.transform.position = position;
        }
    }

    private void OnSwipeEnd(EventContext context)
    {
        if (EnableSwipe)
        {
            SwipeGesture gesture = (SwipeGesture)context.sender;
            Vector3 offset = new Vector3(gesture.velocity.x, 0, -gesture.velocity.y);
            Vector3 v = SceneRotate * offset / InertiaingRatio;
            GTween.To(1, 0, 0.3f).SetTarget(m_CameraCenter).OnUpdate(
                (GTweener tweener) =>
                {
                    v = v * 0.8f; v.y = 0;

                    Vector3 position = m_CameraCenter.transform.position - v;
                    position.x = Mathf.Clamp(position.x, 0.8f, 38.5f);
                    position.z = Mathf.Clamp(position.z, 0, 40f);
                    m_CameraCenter.transform.position = position;
                });
        }
    }

    public void ShowSceneOptUI(int uid)
    {
        var data = GameEntry.TempData.ObjectScene.GetSceneObjectData(uid);
        ZooObjectController zooObjectController;
        if (m_BuildingGoMap.TryGetValue(uid, out zooObjectController))
        {
            SceneOptController.ShowUISceneOpt(data.BuildData, zooObjectController);
            GameEntry.TempData.Edit.SetSelectedBuildData(data.BuildData);
        }
    }

    public void HideSceneOptUI()
    {
        SceneOptController.HideUISceneOpt();
        GameEntry.TempData.Edit.SetSelectedBuildData(null);
    }
}
