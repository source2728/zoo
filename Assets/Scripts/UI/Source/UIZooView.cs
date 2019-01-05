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

    protected bool _IsShowingMenu;
    protected bool IsShowingMenu
    {
        get { return _IsShowingMenu; }
        set
        {
            if (value)
            {
                UI.GetTransition("ShowMenu").Play();
            }
            else
            {
                UI.GetTransition("HideMenu").Play();
            }
            _IsShowingMenu = value;
        }
    }

    protected override void DoShown(object userData)
    {
        GameEntry.Event.Subscribe(EvtTempDataUpdated.EventId, OnEvtTempDataUpdated);
        UI.m_BtnHand.visible = false;
        _IsShowingMenu = false;
        Inst = this;
        var evt = ReferencePool.Acquire<EvtMainUIShown>();
        GameEntry.Event.Fire(this, evt);
    }

    protected override void OnHide()
    {
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

        UI.m_BtnMenu.onClick.Set(OnClickMenu);
        UI.m_BtnCloseEdit.onClick.Set(OnCloseEdit);
        UI.m_BtnEnterBuild.onClick.Set(OnClickEnterBuild);
        UI.m_BtnEnterEdit.onClick.Set(OnClickEnterEdit);
        UI.m_BtnUndo.onClick.Set(OnUndoEdit);
        UI.m_BtnResetData.onClick.Set(OnResetData);

        UI.m_BtnLook.onChanged.Set(OnChangeLookState);
        UI.m_BtnHand.onChanged.Set(OnChangeHandState);
    }

    private void OnResetData()
    {
        GameEntry.Database.ResetGame();
    }

    private void OnUndoEdit()
    {
        var evt = ReferencePool.Acquire<EvtEditUndo>();
        GameEntry.Event.Fire(this, evt);
    }

    private void OnChangeViewState(EventContext context)
    {
        if (UI.m_ViewState.selectedIndex != 0)
        {
            UI.m_BuildType.selectedIndex = 1;
        }
    }

    private void OnChangeHandState(EventContext context)
    {
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

    private void OnClickMenu(EventContext context)
    {
        IsShowingMenu = !IsShowingMenu;
    }

    private void OnClickMenuItem(EventContext context)
    {
        GObject btnObject = context.data as GObject;
        switch (btnObject.name)
        {
            case "MenuInfo":
                GameEntry.UI.OpenUIForm<UI_PanelTotalInfo>();              
                break;

            case "MenuBuild":
                GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtEnterBuildEdit>());
                UI.m_ViewState.selectedIndex = 1;
                break;

            case "MenuDamage":
                GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtEnterDamageEdit>());
                UI.m_ViewState.selectedIndex = 2;
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
        IsShowingMenu = false;
    }

    private void OnCloseEdit(EventContext context)
    {
        UI.m_ViewState.selectedIndex = 0;
        var evt = ReferencePool.Acquire<EvtFinishEdit>();
        evt.IsConfirmEdit = false;
        GameEntry.Event.Fire(this, evt);
    }

    private void OnChangeBuildType()
    {
        switch (UI.m_BuildType.selectedIndex)
        {
            case 1:
                UI.m_ListBuildItems.SetData(GameEntry.DataTable.GetDataTable<DRFence>().GetAllDataRows());
                break;

            case 2:
                UI.m_ListBuildItems.SetData(GameEntry.DataTable.GetDataTable<DRLand>().GetAllDataRows());
                break;

            case 3:
                UI.m_ListBuildItems.SetData(GameEntry.DataTable.GetDataTable<DRAnimal>().GetAllDataRows());
                break;

            case 4:
                UI.m_ListBuildItems.SetData(GameEntry.DataTable.GetDataTable<DRFacility>().GetAllDataRows());
                break;

            case 5:
                UI.m_ListBuildItems.SetData(GameEntry.DataTable.GetDataTable<DRShop>().GetAllDataRows());
                break;
        }
        UI.m_ListBuildItems.selectedIndex = 0;
        OnChangeBuildItem();
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
//            GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());
            //            var evt = ReferencePool.Acquire<EvtChangeBuildItem>();
            //            evt.ObjectType = (EZooObjectType)UI.m_BuildType.selectedIndex;
            //            evt.ObjectId = 0;
            //            GameEntry.Event.Fire(this, evt);
        }
        else
        {
            GameEntry.TempData.Edit.UpdateSelectBuildInfo((EZooObjectType)UI.m_BuildType.selectedIndex, 
                UI.m_ListBuildItems.GetSelectedData<IDataRow>().Id);
//            GameEntry.Event.Fire(this, ReferencePool.Acquire<EvtTempDataUpdated>());
            //            var evt = ReferencePool.Acquire<EvtChangeBuildItem>();
            //            evt.ObjectType = (EZooObjectType)UI.m_BuildType.selectedIndex;
            //            evt.ObjectId = UI.m_ListBuildItems.GetSelectedData<IDataRow>().Id;
            //            GameEntry.Event.Fire(this, evt);
        }

        LastSelectBuildType = UI.m_BuildType.selectedIndex;
        LastSelectBuildId = UI.m_ListBuildItems.selectedIndex;
    }

    private void OnBuildItemRenderer(int index, GObject obj)
    {  
        var item = obj as UI_FilletBig;

        switch (UI.m_BuildType.selectedIndex)
        {
            case 1:
            {
                var data = UI.m_ListBuildItems.GetData<DRFence>(index);
                item.m_LabelCost.SetText(data.BuildCost);
                break;
            }
                
            case 2:
            {
                var data = UI.m_ListBuildItems.GetData<DRLand>(index);
                item.m_LabelCost.SetText(data.BuildCost);
                break;
            }
                
            case 3:
            {
                var data = UI.m_ListBuildItems.GetData<DRAnimal>(index);
                item.m_LabelCost.SetText(data.BuyCost);
                break;
            }

            case 4:
            {
                var data = UI.m_ListBuildItems.GetData<DRFacility>(index);
                item.m_LabelCost.SetText(data.BuildCost);
                break;
            }

            case 5:
            {
                var data = UI.m_ListBuildItems.GetData<DRShop>(index);
                item.m_LabelCost.SetText(data.BuildCost);
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
    }

    private void OnClickEnterBuild()
    {
        BuildObjectCommand.Do();
    }

    private void OnClickEnterEdit()
    {
        EditObjectCommand.Do();
//        UI.m_ViewState.selectedIndex = 0;
//        var evt = ReferencePool.Acquire<EvtConfirmEdit>();
//        GameEntry.Event.Fire(this, evt);
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