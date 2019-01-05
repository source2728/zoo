using System;
using DataTable;
using FairyGUI;
using Zoo;
public class UIPanelFire : UIFormWin
{
	public UI_PanelFire UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelFire;
        UI.m_BtnEnter.onClick.Set(OnClickEnter);
	}

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
    {
        var data = userData as StaffData;
        UI.m_LabelContent.SetValue(data.Name);
        UI.m_LabelCost.SetText(FireStaffCommand.GetCost(data.Id));
    }

    private void OnClickEnter()
    {
        var data = UserData as StaffData;
        FireStaffCommand.Do(data);
        Close();
    }
}
