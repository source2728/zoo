using System;
using FairyGUI;
using Zoo;
public class UIPanelRename : UIFormWin
{
    public class PanelInfo
    {
        public RenameCommand.EType Type;
        public string OriName;
    }

	public UI_PanelRename UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelRename;
	    UI.m_BtnEnter.onClick.Set(OnClickEnter);
    }

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
	{
	    var panelInfo = userData as PanelInfo;
	    UI.m_LabelCost.SetText(RenameCommand.GetCurrencyCost(panelInfo.Type));
        UI.m_InputName.text = panelInfo.OriName;
	}

    private void OnClickEnter(EventContext context)
    {
        var panelInfo = UserData as PanelInfo;
        RenameCommand.Do(panelInfo.Type, panelInfo.OriName, UI.m_InputName.text);
        Close();
    }
}
