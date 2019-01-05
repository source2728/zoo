using Zoo;

public class UIFormWinDefault : UIFormWin
{
    public UI_PanelTotalInfo UI { get; private set; }

    protected override void OnInit()
    {
        base.OnInit();
        UI = contentPane as UI_PanelTotalInfo;
    }

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
    {

    }
}