using System;
using FairyGUI;
using Zoo;
public class UIPanelZooInfo : UIFormWin
{
	public UI_PanelZooInfo UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelZooInfo;
        UI.m_List.onClickItem.Set(OnClickItem);
	}

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
	{
	    int[] ids = {1, 2, 3};
	    UI.m_List.SetData(ids);
    }

    private void OnClickItem(EventContext context)
    {
        GameEntry.UI.OpenUIForm<UI_PanelAnimalList>();
    }
}
