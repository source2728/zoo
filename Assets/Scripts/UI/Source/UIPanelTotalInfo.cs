using System;
using FairyGUI;
using Zoo;
public class UIPanelTotalInfo : UIFormWin
{
	public UI_PanelTotalInfo UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelTotalInfo;
	    UI.m_TabActorInfo.m_BtnRename.onClick.Set(OnClickRenameActor);
	    UI.m_TabSecretaryInfo.m_BtnRename.onClick.Set(OnClickRenameSecretary);
	    UI.m_TabGuardInfo.m_BtnRename.onClick.Set(OnClickRenameGuard);
        UI.m_TabZooInfo.m_BtnRename.onClick.Set(OnClickRenameZoo);
        UI.m_ViewState.onChanged.Set(OnRefreshTabContent);
    }

    protected override void DoShown(object userData)
	{
	    UI.m_ViewState.selectedIndex = 1;
    }

	protected override void DoRefresh(object userData)
	{
	    OnRefreshTabContent();
	}

    private void OnRefreshTabContent()
    {
        switch (UI.m_ViewState.selectedIndex)
        {
            case 1:
                UI.m_TabActorInfo.OnRefresh(GameEntry.Database.Actor.ActorData,
                    GameEntry.Database.Currency.GetCurrencyValue(ECurrencyType.Gold));
                break;

            case 2:
                UI.m_TabSecretaryInfo.OnRefresh(GameEntry.Database.Actor.ActorData);
                break;

            case 3:
                UI.m_TabGuardInfo.OnRefresh(GameEntry.Database.Actor.ActorData);
                break;

            case 4:
                UI.m_TabZooInfo.OnRefresh(GameEntry.Database.Zoo.ZooData,
                    GameEntry.Database.Currency.GetCurrencyValue(ECurrencyType.Gold));
                break;
        }
    }

    private void OnClickRenameActor()
    {
        var panelInfo = new UIPanelRename.PanelInfo();
        panelInfo.Type = RenameCommand.EType.Actor;
        panelInfo.OriName = GameEntry.Database.Actor.ActorData.ActorName;
        GameEntry.UI.OpenUIForm<UI_PanelRename>(panelInfo);
    }

    private void OnClickRenameSecretary()
    {
        var panelInfo = new UIPanelRename.PanelInfo();
        panelInfo.Type = RenameCommand.EType.Secretary;
        panelInfo.OriName = GameEntry.Database.Actor.ActorData.SecretaryName;
        GameEntry.UI.OpenUIForm<UI_PanelRename>(panelInfo);
    }

    private void OnClickRenameGuard()
    {
        var panelInfo = new UIPanelRename.PanelInfo();
        panelInfo.Type = RenameCommand.EType.Guard;
        panelInfo.OriName = GameEntry.Database.Actor.ActorData.GuardName;
        GameEntry.UI.OpenUIForm<UI_PanelRename>(panelInfo);
    }

    private void OnClickRenameZoo()
    {
        var panelInfo = new UIPanelRename.PanelInfo();
        panelInfo.Type = RenameCommand.EType.Zoo;
        panelInfo.OriName = GameEntry.Database.Zoo.ZooData.Name;
        GameEntry.UI.OpenUIForm<UI_PanelRename>(panelInfo);
    }
}
