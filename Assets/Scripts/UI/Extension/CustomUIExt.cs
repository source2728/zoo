using Common;
using FairyGUI;
using Zoo;

public static class CustomUIExt
{
    public static void OnRefresh(this UI_TabActorInfo ui, ActorData actorData, int money)
    {
        ui.m_LabelHonor.SetText(actorData.ActorHonorName);
        ui.m_StarLevel.SetStarLevel(actorData.ActorPopular);
        ui.m_LabelIncomeBonus.SetValue(actorData.IncomeBonus);
        ui.m_LabelMoney.SetText(money);
        ui.m_LabelName.SetText(actorData.ActorName);
    }

    public static void OnRefresh(this UI_TabSecretaryInfo ui, ActorData actorData)
    {
        ui.m_LabelDialog.SetText(GameEntry.Database.DefaultLocalData.RandSecretaryDialog());
        ui.m_LabelName.SetText(actorData.SecretaryName);

        var dialog = ui.m_LabelDialog as UI_PanelFrameDialog;
        dialog.m_BtnEnter.onClick.Set((() =>
        {
            ui.m_LabelDialog.SetText(GameEntry.Database.DefaultLocalData.RandSecretaryDialog());
        }));
    }

    public static void OnRefresh(this UI_TabGuardInfo ui, ActorData actorData)
    {
        ui.m_LabelDialog.SetText(GameEntry.Database.DefaultLocalData.RandGuardDialog());
        ui.m_LabelName.SetText(actorData.GuardName);

        var dialog = ui.m_LabelDialog as UI_PanelFrameDialog;
        dialog.m_BtnEnter.onClick.Set((() =>
        {
            ui.m_LabelDialog.SetText(GameEntry.Database.DefaultLocalData.RandGuardDialog());
        }));
    }

    public static void OnRefresh(this UI_TabZooInfo ui, ZooData zooData, int money)
    {
        ui.m_LabelName.SetText(zooData.Name);
        ui.m_StarLevelPopular.SetStarLevel(zooData.Popular);
//        ui.m_StarLevelLike.SetStarLevel(zooData.VisitorLike);
        ui.m_LabelVisitor.SetText(zooData.VisitorCount);
        ui.m_LabelMoney.SetText(money);
        ui.m_LabelIncome.SetText(zooData.ExpectIncome);
        ui.m_LabelPrice.SetText(zooData.Price);
        ui.m_BtnSettingPrice.onClick.Set((() =>
        {
            GameEntry.UI.OpenUIForm<UI_PanelZooSetting>();
        }));
    }
}
