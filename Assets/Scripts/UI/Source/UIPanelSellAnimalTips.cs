using System;
using DataTable;
using FairyGUI;
using UnityGameFramework.Runtime;
using Zoo;
public class UIPanelSellAnimalTips : UIFormWin
{
	public UI_PanelSellAnimalTips UI { get; private set; }

	protected override void DoShown(object userData)
	{
	    var deploy = GameEntry.DataTable.GetDataTableRow<DRAnimal>((int) userData);
	    UI.m_LabelContent.SetValue(deploy.Name);
        UI.m_LabelMoney.SetText(deploy.SellReturn);
    }

	protected override void DoRefresh(object userData)
	{

	}

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelSellAnimalTips;
        UI.m_BtnCancel.onClick.Set(Close);
        UI.m_BtnEnter.onClick.Set(OnClickEnter);
	}

    private void OnClickEnter(EventContext context)
    {
        var animalId = (int)UserData;
        var fenceAreaId = GameEntry.DataNode.GetData<VarInt>("BuyAnimalFenceArea").Value;
        SellAnimalCommand.Do(fenceAreaId, animalId, 1);
        Close();
    }
}
