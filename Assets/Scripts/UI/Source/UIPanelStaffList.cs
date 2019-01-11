using System;
using FairyGUI;
using Zoo;
public class UIPanelStaffList : UIFormWin
{
	public UI_PanelStaffList UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelStaffList;
	    UI.m_List.itemRenderer = OnItemRenderer;
	    UI.m_BtnRecruit.onClick.Set(OnClickRecruit);
    }

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
	{
        UI.m_List.SetData(GameEntry.Database.Staff.StaffList.ToArray());
	}

    private void OnItemRenderer(int index, GObject obj)
    {
        var data = UI.m_List.GetData<StaffData>(index);
        var item = obj as UI_StaffItem;
        item.m_LabelName.SetText(data.Name);
        item.m_LoaderIcon.SetStaffIcon(data.Id);
        item.m_BtnFire.onClick.Set((() =>
        {
            GameEntry.UI.OpenUIForm<UI_PanelFire>(data);
        }));
    }

    private void OnClickRecruit(EventContext context)
    {
        GameEntry.UI.OpenUIForm<UI_PanelRecruitStaff>();
    }
}
