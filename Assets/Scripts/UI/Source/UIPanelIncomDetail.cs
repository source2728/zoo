using Zoo;
public class UIPanelIncomDetail : UIFormWin
{
	public UI_PanelIncomDetail UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelIncomDetail;
	}

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
	{

	}
}
