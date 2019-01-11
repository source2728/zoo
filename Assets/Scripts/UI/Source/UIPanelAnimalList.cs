using System;
using System.Collections.Generic;
using DataTable;
using FairyGUI;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;
using Zoo;
using Random = UnityEngine.Random;

public class UIPanelAnimalList : UIFormWin
{
	public UI_PanelAnimalList UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelAnimalList;
	    UI.m_AttrList.itemRenderer = OnItemRenderer;
        UI.m_AttrList.onClickItem.Set(OnClickItem);
	    UI.m_TypeList.itemRenderer = OnTypeItemRenderer;
	    UI.m_ListBuyItem.itemRenderer = OnBuyItemRenderer;
        UI.m_ListBuyItem.onClickItem.Set(OnClickBuyItem);
        UI.m_BtnJump.onClick.Set(OnClickJump);
	}

    private void OnClickJump(EventContext context)
    {
        var fenceAreaData = UserData as FenceAreaData;

        var evt = ReferencePool.Acquire<EvtJumpToGrid>();
        evt.Grid = fenceAreaData.Fences[0];
        GameEntry.Event.Fire(this, evt);
        Close();
    }

    protected override void DoShown(object userData)
    {
        UI.m_LoaderIcon.SetFenceAreaIcon(1);
    }

    protected override void DoRefresh(object userData)
    {
        var fenceAreaData = userData as FenceAreaData;
        List<int> animalList = new List<int>();
        foreach (var info in fenceAreaData.AnimalCounts)
        {
            for (int i = 0; i < info.y; i++)
            {
                animalList.Add(info.x);
            }
        }
        animalList.Add(0);
        UI.m_AttrList.SetData(animalList.ToArray());

        List<Vector3Int> typeList = new List<Vector3Int>();
        typeList.Add(new Vector3Int(1, 1, fenceAreaData.Fences.Count));
        typeList.Add(new Vector3Int(2, 1, fenceAreaData.GetFences().Count));
        foreach (var info in fenceAreaData.AnimalCounts)
        {
            typeList.Add(new Vector3Int(4, info.x, info.y));
        }
        UI.m_TypeList.SetData(typeList.ToArray());

        UI.m_ListBuyItem.SetData(GameEntry.DataTable.GetDataTable<DRAnimal>().GetAllDataRows());
    }

    private void OnClickItem(EventContext context)
    {
        var item = context.data as UI_AnimalAttributes;
        var data = (int)item.data;
        if (data == 0)
        {
            UI.m_ViewState.selectedIndex = 1;
        }
    }

    private void OnItemRenderer(int index, GObject obj)
    {
        var data = UI.m_AttrList.GetData<int>(index);
        var item = obj as UI_AnimalAttributes;
        item.data = data;

        if (data == 0)
        {
            item.m_ViewState.selectedIndex = 0;
        }
        else
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DRAnimal>(data);
            item.m_ViewState.selectedIndex = 1;
            item.m_LabelName.SetText(deploy.Name);
            item.m_LoaderIcon.SetAnimalIcon(deploy.Id);
            item.m_LabelAttr1.SetValue(Random.Range(50, 200));
            item.m_LabelAttr2.SetValue(Random.Range(50, 200));
            item.m_LabelAttr3.SetValue(Random.Range(50, 200));
            item.m_LabelAttr4.SetValue(Random.Range(50, 200));
            item.m_BtnRemove.onClick.Set(OnClickRemoveAnimal);
            item.m_BtnRemove.data = data;
        }
    }

    private void OnClickRemoveAnimal(EventContext context)
    {
        var fenceAreaDataData = UserData as FenceAreaData;
        var sender = context.sender as GComponent;
        var data = (int)sender.data;
        GameEntry.DataNode.SetData<VarInt>("BuyAnimalFenceArea", fenceAreaDataData.Uid);
        GameEntry.UI.OpenUIForm<UI_PanelSellAnimalTips>(data);
    }

    private void OnTypeItemRenderer(int index, GObject obj)
    {
        var data = UI.m_TypeList.GetData<Vector3Int>(index);
        var item = obj as UI_AnimalQuantity;
        item.m_LabelCount.SetValue(data.z);
        if (data.x == 1)
        {
            item.m_LoaderIcon.SetLandIcon(data.y);
        }
        else if (data.x == 2)
        {
            item.m_LoaderIcon.SetFenceIcon(data.y);
        }
        else if (data.x == 3)
        {
            item.m_LoaderIcon.SetFenceIcon(data.y);
        }
        else if (data.x == 4)
        {
            item.m_LoaderIcon.SetAnimalIcon(data.y);
        }
    }

    private void OnBuyItemRenderer(int index, GObject obj)
    {
        var data = UI.m_ListBuyItem.GetData<DRAnimal>(index);
        var item = obj as UI_AnimalBuyItem;
        item.m_LabelName.SetText(data.Name);
        item.m_LabelMoney.SetText(data.BuyCost);
        item.m_LoaderIcon.SetAnimalIcon(data.Id);
        item.data = data;
    }

    private void OnClickBuyItem(EventContext context)
    {
        var item = context.data as UI_AnimalBuyItem;
        var fenceAreaDataData = UserData as FenceAreaData;
        GameEntry.DataNode.SetData<VarInt>("BuyAnimalFenceArea", fenceAreaDataData.Uid);
        GameEntry.UI.OpenUIForm<UI_PanelBuyAnimalTips>(item.data);
    }
}
