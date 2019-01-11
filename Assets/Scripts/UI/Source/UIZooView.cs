using System;
using System.Collections.Generic;
using DataTable;
using FairyGUI;
using GameFramework;
using GameFramework.DataTable;
using GameFramework.Event;
using Zoo;

public class UIZooView : UIFormWin
{
    public static UIZooView Inst;
    public UI_ZooView UI { get; private set; }

    protected override void DoShown(object userData)
    {
        GameEntry.Event.Subscribe(EvtTempDataUpdated.EventId, OnEvtTempDataUpdated);
        GameEntry.Event.Subscribe(EvtFinishEdit.EventId, OnEvtFinishEdit);
        UI.m_BtnHand.visible = false;
        Inst = this;
        var evt = ReferencePool.Acquire<EvtMainUIShown>();
        GameEntry.Event.Fire(this, evt);
    }

    protected override void OnHide()
    {
        GameEntry.Event.Unsubscribe(EvtFinishEdit.EventId, OnEvtFinishEdit);
        GameEntry.Event.Unsubscribe(EvtTempDataUpdated.EventId, OnEvtTempDataUpdated);
        base.OnHide();
    }

    private void OnEvtTempDataUpdated(object sender, GameEventArgs e)
    {
        RefreshBuildingObjects(GameEntry.TempData.Edit.SummaryObjectList);
        RefreshEditingObjects(GameEntry.TempData.Edit.SummaryObjectList);
    }

    protected override void DoRefresh(object userData)
    {
        var zooData = GameEntry.Database.Zoo.ZooData;
        UI.m_LabelMoney.SetText(GameEntry.Database.Currency.GetCurrencyValue(ECurrencyType.Gold));
        UI.m_LabelIncome.SetText(zooData.ExpectIncome);
        UI.m_LabelVisitorCount.SetText(zooData.VisitorCount);
        UI.m_LabelVisitorLike.SetText(zooData.VisitorLike);
    }

    protected override void OnInit()
    {
        base.OnInit();
        UI = contentPane as UI_ZooView;
        
        UI.m_ListMenu.onClickItem.Set(OnClickMenuItem);
        UI.m_BuildType.onChanged.Set(OnChangeBuildType);
        UI.m_ListBuildItems.itemRenderer = OnBuildItemRenderer;
        UI.m_ListBuildItems.onClickItem.Set(OnChangeBuildItem);
        UI.m_ViewState.onChanged.Set(OnChangeViewState);
        UI.m_ListBuildingObjects.itemRenderer = OnEditObjectItemRenderer;
        UI.m_ListEditingObjects.itemRenderer = OnEditObjectItemRenderer;
        UI.m_ListLand.itemRenderer = OnLandItemRenderer;
        UI.m_ListFence.itemRenderer = OnFenceItemRenderer;
        UI.m_ListLand.onClickItem.Set(OnChangeFenceAreaInfo);
        UI.m_ListFence.onClickItem.Set(OnChangeFenceAreaInfo);

        UI.m_BtnCloseEdit.onClick.Set(OnCloseEdit);
        UI.m_BtnEnterBuild.onClick.Set(OnClickEnterBuild);
        UI.m_BtnEnterEdit.onClick.Set(OnClickEnterEdit);
        UI.m_BtnUndo.onClick.Set(OnUndoEdit);
        UI.m_BtnResetData.onClick.Set(OnResetData);

        UI.m_BtnLook.onChanged.Set(OnChangeLookState);
        UI.m_BtnHand.onChanged.Set(OnChangeHandState);
    }

    private void OnFenceItemRenderer(int index, GObject obj)
    {
        var data = UI.m_ListFence.GetData<DRFence>(index);
        var item = obj as UI_ItemFenceAreaBuild;
        item.m_LabelName.SetText(data.Name);
        item.m_LoaderIcon.SetFenceIcon(data.Id);
    }

    private void OnLandItemRenderer(int index, GObject obj)
    {
        var data = UI.m_ListLand.GetData<DRLand>(index);
        var item = obj as UI_ItemFenceAreaBuild;
        item.m_LabelName.SetText(data.Name);
        item.m_LoaderIcon.SetLandIcon(data.Id);
    }

    private void OnResetData()
    {
        GameEntry.Database.ResetGame();
        GameEntry.TempData.Reset();
        GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtDataReseted>());
    }

    private void OnUndoEdit()
    {
        var evt = ReferencePool.Acquire<EvtEditUndo>();
        GameEntry.Event.Fire(this, evt);
    }

    private void OnChangeViewState(EventContext context)
    {
        if (UI.m_ViewState.selectedIndex == 1)
        {
            GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtEnterBuildEdit>());
        }
        else if (UI.m_ViewState.selectedIndex == 2)
        {
            GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtEnterDamageEdit>());
        }
        else if (UI.m_ViewState.selectedIndex == 3)
        {
            GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtEnterFenceAreaEdit>());
        }
    }

    private void OnChangeHandState(EventContext context)
    {
        if (!UI.m_BtnHand.selected)
        {
            UI.m_ListBuildItems.selectedIndex = 0;
            GameEntry.TempData.Edit.UpdateSelectBuildInfo((EZooObjectType)UI.m_BuildType.selectedIndex,
                UI.m_ListBuildItems.GetSelectedData<IDataRow>().Id);
        }

        var evt = ReferencePool.Acquire<EvtChangeTouchState>();
        evt.CanSwipeScene = UI.m_BtnHand.selected;
        GameEntry.Event.Fire(this, evt);
    }

    private void OnChangeLookState(EventContext context)
    {
        var evt = ReferencePool.Acquire<EvtChangeLookState>();
        evt.CanLookEditedObject = UI.m_BtnLook.selected;
        GameEntry.Event.Fire(this, evt);
    }

    private void OnClickMenuItem(EventContext context)
    {
        GObject btnObject = context.data as GObject;
        switch (btnObject.name)
        {
            case "MenuInfo":
                GameEntry.UI.OpenUIForm<UI_PanelTotalInfo>();              
                break;

            case "MenuAnimal":
                GameEntry.UI.OpenUIForm<UI_PanelZooInfo>();
                break;

            case "MenuShop":
                GameEntry.UI.OpenUIForm<UI_PanelShopList>();
                break;

            case "MenuHandbook":
                GameEntry.UI.OpenUIForm<UI_PanelHandbook>();
                break;

            case "MenuStaff":
                GameEntry.UI.OpenUIForm<UI_PanelStaffList>();
                break;

            case "MenuEvent":
                GameEntry.UI.OpenUIForm<UI_PanelEventList>();
                break;

            case "MenuAchievement":
                GameEntry.UI.OpenUIForm<UI_PanelAchievement>();
                break;
        }

        UI.m_MainMenuState.selectedIndex = 0;
    }

    private void OnCloseEdit(EventContext context)
    {
        var evt = ReferencePool.Acquire<EvtFinishEdit>();
        evt.IsConfirmEdit = false;
        GameEntry.Event.Fire(this, evt);
    }

    private void OnEvtFinishEdit(object sender, GameEventArgs e)
    {
        UI.m_ViewState.selectedIndex = 0;
    }

    private void OnChangeBuildType()
    {
        switch (UI.m_BuildType.selectedIndex)
        {
            case 4:
                UI.m_ListBuildItems.SetData(GameEntry.DataTable.GetDataTable<DRLand>().GetAllDataRows());
                break;

            case 3:
                UI.m_ListBuildItems.SetData(GameEntry.DataTable.GetDataTable<DRFacility>().GetAllDataRows());
                break;

            case 2:
                UI.m_ListBuildItems.SetData(GameEntry.DataTable.GetDataTable<DRShop>().GetAllDataRows());
                break;
        }

        if (UI.m_BuildType.selectedIndex > 1)
        {
            UI.m_ListBuildItems.selectedIndex = 0;
            OnChangeBuildItem();
        }
        else if (UI.m_BuildType.selectedIndex == 1)
        {
            //            UI.m_ListLand.SetData(GameEntry.DataTable.GetDataTable<DRLand>().GetAllDataRows());
            //            UI.m_ListFence.SetData(GameEntry.DataTable.GetDataTable<DRFence>().GetAllDataRows());

            UI.m_ListLand.SetData(new DRLand[]{ GameEntry.DataTable.GetDataTableRow<DRLand>(5) });
            UI.m_ListFence.SetData(new DRFence[] { GameEntry.DataTable.GetDataTableRow<DRFence>(1) });
            UI.m_ListLand.selectedIndex = 0;
            UI.m_ListFence.selectedIndex = 0;
            OnChangeFenceAreaInfo();
        }
    }

    private void OnChangeFenceAreaInfo()
    {
        GameEntry.TempData.Edit.UpdateSelectFenceAreaInfo(UI.m_ListLand.GetSelectedData<IDataRow>().Id,
            UI.m_ListFence.GetSelectedData<IDataRow>().Id);
    }

    public int LastSelectBuildType = -1;
    public int LastSelectBuildId = -1;
    private void OnChangeBuildItem()
    {
        if (LastSelectBuildType == UI.m_BuildType.selectedIndex && 
            LastSelectBuildId == UI.m_ListBuildItems.selectedIndex)
        {
            UI.m_ListBuildItems.selectedIndex = -1;
            GameEntry.TempData.Edit.UpdateSelectBuildInfo((EZooObjectType) UI.m_BuildType.selectedIndex, 0);
        }
        else
        {
            GameEntry.TempData.Edit.UpdateSelectBuildInfo((EZooObjectType)UI.m_BuildType.selectedIndex, 
                UI.m_ListBuildItems.GetSelectedData<IDataRow>().Id);
        }

        LastSelectBuildType = UI.m_BuildType.selectedIndex;
        LastSelectBuildId = UI.m_ListBuildItems.selectedIndex;
    }

    private void OnBuildItemRenderer(int index, GObject obj)
    {  
        var item = obj as UI_FilletBig;

        switch (UI.m_BuildType.selectedIndex)
        {                
            case 4:
            {
                var data = UI.m_ListBuildItems.GetData<DRLand>(index);
                item.m_LabelCost.SetText(data.BuildCost);
                item.m_LoaderIcon.SetLandIcon(data.Id);
                break;
            }

            case 3:
            {
                var data = UI.m_ListBuildItems.GetData<DRFacility>(index);
                item.m_LabelCost.SetText(data.BuildCost);
                item.m_LoaderIcon.SetFacilityIcon(data.Id);
                break;
            }

            case 2:
            {
                var data = UI.m_ListBuildItems.GetData<DRShop>(index);
                item.m_LabelCost.SetText(data.BuildCost);
                item.m_LoaderIcon.SetShopIcon(data.Id);
                break;
            }
        }
    }

    public void RefreshBuildingObjects(List<BuildData> datas)
    {
        UI.m_ListBuildingObjects.SetData(datas.ToArray());

        int cost = 0;
        foreach (var data in datas)
        {
            cost += data.Count * data.GetCost();
        }
        UI.m_BtnEnterBuild.text = cost.ToString();
    }

    public void RefreshEditingObjects(List<BuildData> datas)
    {
        UI.m_ListEditingObjects.SetData(datas.ToArray());

        int cost = 0;
        foreach (var data in datas)
        {
            cost += data.Count * data.GetCost();
        }
        UI.m_BtnEnterEdit.text = cost.ToString();
    }

    private void OnEditObjectItemRenderer(int index, GObject obj)
    {
        var data = UI.m_ListBuildingObjects.GetData<BuildData>(index);
        var item = obj as UI_FilletSmall;
        item.m_LabelCount.SetValue(data.Count);
        item.m_LabelMoney.SetText(data.Count * data.GetCost());
        if (data.BuildType == (int) EZooObjectType.Land)
        {
            item.m_LoaderIcon.SetLandIcon(data.BuildId);
        }
        else if (data.BuildType == (int)EZooObjectType.Facility)
        {
            item.m_LoaderIcon.SetFacilityIcon(data.BuildId);
        }
        else if (data.BuildType == (int)EZooObjectType.Shop)
        {
            item.m_LoaderIcon.SetShopIcon(data.BuildId);
        }
    }

    private void OnClickEnterBuild()
    {
        BuildObjectCommand.Do();
    }

    private void OnClickEnterEdit()
    {
        if (UI.m_ViewState.selectedIndex == 2)
        {
            EditObjectCommand.Do();
        }
        else if (UI.m_ViewState.selectedIndex == 3)
        {
            BuildObjectCommand.Do();
        }
    }

    public void RefreshWithBuildInEditMode()
    {
        UI.m_BtnHand.selected = true;
        UI.m_ListBuildItems.selectedIndex = -1;
        LastSelectBuildId = -1;
    }

    public void RefreshWithBuildInBuildMode()
    {
        UI.m_BtnHand.selected = false;
    }
}