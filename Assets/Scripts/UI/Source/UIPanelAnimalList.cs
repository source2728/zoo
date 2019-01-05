using Zoo;
public class UIPanelAnimalList : UIFormWin
{
	public UI_PanelAnimalList UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelAnimalList;
	}

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
	{

	}
}
