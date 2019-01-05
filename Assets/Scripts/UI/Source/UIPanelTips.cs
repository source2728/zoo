using Zoo;
public class UIPanelTips : UIFormWin
{
	public UI_PanelTips UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelTips;
	}

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
	{

	}
}
