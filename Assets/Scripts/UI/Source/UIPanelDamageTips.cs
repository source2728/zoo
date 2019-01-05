using Zoo;
public class UIPanelDamageTips : UIFormWin
{
	public UI_PanelDamageTips UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelDamageTips;
	}

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
	{

	}
}
