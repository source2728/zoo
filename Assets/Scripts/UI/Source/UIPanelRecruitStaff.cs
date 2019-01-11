using System;
using DataTable;
using FairyGUI;
using UnityGameFramework.Runtime;
using Zoo;
public class UIPanelRecruitStaff : UIFormWin
{
	public UI_PanelRecruitStaff UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelRecruitStaff;
	    UI.m_List.itemRenderer = OnItemRenderer;
	    UI.m_List.onClickItem.Set(OnClickItem);
    }

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
    {
        var drStaffs = GameEntry.DataTable.GetDataTable<DRStaff>();
        UI.m_List.SetData(drStaffs.GetAllDataRows());
	}

    private void OnItemRenderer(int index, GObject obj)
    {
        var data = UI.m_List.GetData<DRStaff>(index);
        var item = obj as UI_Instructor;
        item.m_LabelName.SetText(data.Name);
        item.m_LabelCost.SetText(data.RecruitCost);
        item.m_LoaderIcon.SetStaffIcon(data.Id);
    }

    private void OnClickItem(EventContext context)
    {
        GameEntry.UI.OpenUIForm<UI_PanelRecruit>(UI.m_List.GetSelectedData<DRStaff>());
    }
}
