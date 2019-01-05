using Zoo;
public class UIPanelAchievement : UIFormWin
{
	public UI_PanelAchievement UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelAchievement;
	}

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
	{

	}
}
