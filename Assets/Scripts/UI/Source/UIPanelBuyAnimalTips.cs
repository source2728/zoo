using System;
using DataTable;
using FairyGUI;
using UnityGameFramework.Runtime;
using Zoo;
public class UIPanelBuyAnimalTips : UIFormWin
{
	public UI_PanelBuyAnimalTips UI { get; private set; }

	protected override void DoShown(object userData)
	{
	    var data = userData as DRAnimal;
        UI.m_LabelCost.SetText(data.BuyCost);
	    UI.m_LabelContent.SetValue(data.Name);
    }

	protected override void DoRefresh(object userData)
	{

	}

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelBuyAnimalTips;
	    UI.m_BtnCancel.onClick.Set(Close);
        UI.m_BtnEnter.onClick.Set(OnClickEnter);
    }

    private void OnClickEnter(EventContext context)
    {
        var data = UserData as DRAnimal;
        var fenceAreaId = GameEntry.DataNode.GetData<VarInt>("BuyAnimalFenceArea").Value;
        BuyAnimalCommand.Do(fenceAreaId, data.Id, 1);
        Close();
    }
}
