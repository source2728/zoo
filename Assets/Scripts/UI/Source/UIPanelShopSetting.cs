using System;
using FairyGUI;
using UnityEngine;
using UnityGameFramework.Runtime;
using Zoo;
public class UIPanelShopSetting : UIFormWin
{
	public UI_PanelShopSetting UI { get; private set; }

    private int _Price;
    protected int Price
    {
        get { return _Price; }
        set
        {
            _Price = value;
            UI.m_LabelPrice.SetText(value);
        }
    }

    protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelShopSetting;
	    UI.m_BtnCancel.onClick.Set(Close);
        UI.m_BtnSetting.onClick.Set(OnClickSetting);
        UI.m_BtnMinus.onClick.Set(OnClickMinus);
	    UI.m_BtnPlus.onClick.Set(OnClickPlus);
	    UI.m_LabelPrice.editable = true;
	    UI.m_LabelPrice.GetTextField().asTextInput.onChanged.Set(OnPriceChange);
    }

    protected override void DoShown(object userData)
    {
        var data = userData as ShopData;
        Price = data.Price;
    }

    private void OnClickSetting(EventContext context)
    {
        var data = UserData as ShopData;
        SetShopPriceCommand.Do(data.Id, Price);
    }

    private void OnClickPlus(EventContext context)
    {
        Price = Math.Min(100, Price + 1);
    }

    private void OnClickMinus(EventContext context)
    {
        Price = Math.Max(1, Price - 1);
    }

    private void OnPriceChange(EventContext context)
    {
        if (UI.m_LabelPrice.text.Length > 0)
        {
            int newPrice = int.Parse(UI.m_LabelPrice.text);
            Price = Mathf.Clamp(newPrice, 1, 100);
        }
        else
        {
            Price = 1;
        }
    }
}
