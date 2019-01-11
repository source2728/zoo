/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelSellAnimalTips : GComponent
	{
		public GTextField m_LabelContent;
		public GTextField m_LabelMoney;
		public GButton m_BtnCancel;
		public GButton m_BtnEnter;

		public const string URL = "ui://5voe50hllkym9y";

		public static UI_PanelSellAnimalTips CreateInstance()
		{
			return (UI_PanelSellAnimalTips)UIPackage.CreateObject("Zoo","PanelSellAnimalTips");
		}

		public UI_PanelSellAnimalTips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelContent = (GTextField)this.GetChildAt(2);
			m_LabelMoney = (GTextField)this.GetChildAt(3);
			m_BtnCancel = (GButton)this.GetChildAt(5);
			m_BtnEnter = (GButton)this.GetChildAt(6);
		}
	}
}