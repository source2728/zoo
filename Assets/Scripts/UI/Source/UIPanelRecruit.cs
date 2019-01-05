using DataTable;
using Zoo;
public class UIPanelRecruit : UIFormWin
{
	public UI_PanelRecruit UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelRecruit;
	    UI.m_BtnEnter.onClick.Set(OnClickEnter);
    }

	protected override void DoShown(object userData)
	{

	}

	protected override void DoRefresh(object userData)
	{
	    DRStaff data = userData as DRStaff;
	    UI.m_LabelCost.SetText(RecruitStaffCommand.GetCost(data));
	    UI.m_InputName.text = data.Name;
	}

    private void OnClickEnter()
    {
        var data = UserData as DRStaff;
        RecruitStaffCommand.Do(data, UI.m_InputName.text);
        Close();
    }
}
