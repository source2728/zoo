using System;
using FairyGUI;
using Zoo;
public class UIPanelZooSetting : UIFormWin
{
	public UI_PanelZooSetting UI { get; private set; }

    private int _CurSettingPrice;
    protected int CurSettingPrice
    {
        get
        {
            return _CurSettingPrice;
        }
        set
        {
            if (_CurSettingPrice != value)
            {
                _CurSettingPrice = value;
                UI.m_LabelPrice.SetText(_CurSettingPrice);
            }
        }
    }

    protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelZooSetting;
        UI.m_BtnCancel.onClick.Set(Close);
	    UI.m_BtnSetting.onClick.Set(OnClickSetting);
	    UI.m_BtnMinus.onClick.Set(OnClickMinus);
	    UI.m_BtnPlus.onClick.Set(OnClickPlus);
    }

    protected override void DoShown(object userData)
    {
        CurSettingPrice = GameEntry.Database.Zoo.ZooData.Price;
    }

	protected override void DoRefresh(object userData)
	{
	}

    private void OnClickSetting()
    {
        SetZooPriceCommand.Do(CurSettingPrice);
    }

    private void OnClickMinus()
    {
        CurSettingPrice = Math.Max(1, CurSettingPrice - 1);
    }

    private void OnClickPlus()
    {
        CurSettingPrice = Math.Min(100, CurSettingPrice + 1);
    }
}
