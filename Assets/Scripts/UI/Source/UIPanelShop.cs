using System;
using DataTable;
using FairyGUI;
using Zoo;
public class UIPanelShop : UIFormWin
{
	public UI_PanelShop UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelShop;
	    UI.m_BtnCancel.onClick.Set(Close);
        UI.m_BtnSetting.onClick.Set(OnClickSetting);
	}

    protected override void DoShown(object userData)
    {
    }

    protected override void DoRefresh(object userData)
    {
        var data = userData as ShopData;
        var deploy = GameEntry.DataTable.GetDataTableRow<DRShop>(data.Id);

        UI.m_frame.SetText(data.Name);
        UI.m_LabelTotalVisitorCount.SetValue(data.TodayVisitor);
        UI.m_LabelTotalIncome.SetValue(data.TodayIncome);
        UI.m_LabelInPrice.SetValue(0);
        UI.m_LabelOutPrice.SetValue(data.Price);
        UI.m_LabelTax.SetValue(deploy.Tax);

        UI.m_LabelVisitorCount.SetText(data.TodayVisitor);
        UI.m_LabelIncome.SetText(data.TodayIncome);
    }

    private void OnClickSetting(EventContext context)
    {
        GameEntry.UI.OpenUIForm<UI_PanelShopSetting>(UserData);
    }
}
