using System;
using FairyGUI;
using GameFramework.Event;
using Zoo;
public class UIPanelShopList : UIFormWin
{
	public UI_PanelShopList UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelShopList;
	    UI.m_List.onClickItem.Set(OnClickItem);
	    UI.m_List.itemRenderer = OnItemRenderer;
	}

    protected override void DoShown(object userData)
    {
        GameEntry.Event.Subscribe(EvtJumpToGrid.EventId, OnEvtJumpToGrid);
    }

    protected override void DoHide(object userData)
    {
        GameEntry.Event.Unsubscribe(EvtJumpToGrid.EventId, OnEvtJumpToGrid);
    }

    protected override void DoRefresh(object userData)
	{
	    UI.m_List.SetData(GameEntry.Database.Shop.ShopList.ToArray());
    }

    private void OnItemRenderer(int index, GObject obj)
    {
        var data = UI.m_List.GetData<ShopData>(index);
        var item = obj as UI_Shop;
        item.m_LabelName.SetText(data.Name);
        item.m_LabelVisitorCount.SetText(data.TodayVisitor);
        item.m_LabelIncome.SetText(data.TodayIncome);
        item.m_LoaderIcon.SetShopIcon(data.Id);
    }

    private void OnClickItem(EventContext context)
    {
        GameEntry.UI.OpenUIForm<UI_PanelShop>(UI.m_List.GetSelectedData<ShopData>());
    }

    private void OnEvtJumpToGrid(object sender, GameEventArgs e)
    {
        Close();
    }
}
