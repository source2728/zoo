using System;
using FairyGUI;
using GameFramework.Event;
using Zoo;
public class UIPanelZooInfo : UIFormWin
{
	public UI_PanelZooInfo UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelZooInfo;
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

    private void OnEvtJumpToGrid(object sender, GameEventArgs e)
    {
        Close();
    }

    protected override void DoRefresh(object userData)
	{
	    UI.m_List.SetData(GameEntry.Database.FenceArea.FenceAreaList.ToArray());
    }

    private void OnItemRenderer(int index, GObject obj)
    {
        var data = UI.m_List.GetData<FenceAreaData>(index);
        var item = obj as UI_Zoo;
        item.title = data.Name.Length > 0 ? data.Name : "动物围栏";
        item.m_LoaderIcon.SetFenceAreaIcon(1);
    }

    private void OnClickItem(EventContext context)
    {
        GameEntry.UI.OpenUIForm<UI_PanelAnimalList>(UI.m_List.GetSelectedData<FenceAreaData>());
    }
}
