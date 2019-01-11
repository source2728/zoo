/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelShop : GComponent
	{
		public GLabel m_frame;
		public GTextField m_LabelTotalVisitorCount;
		public GTextField m_LabelTotalIncome;
		public GTextField m_LabelInPrice;
		public GTextField m_LabelOutPrice;
		public GTextField m_LabelTax;
		public GTextField m_LabelIncome;
		public GTextField m_LabelVisitorCount;
		public GLoader m_LoaderIcon;
		public GButton m_BtnCancel;
		public GButton m_BtnSetting;
		public GComponent m_BtnJump;

		public const string URL = "ui://5voe50hlsbaz4l";

		public static UI_PanelShop CreateInstance()
		{
			return (UI_PanelShop)UIPackage.CreateObject("Zoo","PanelShop");
		}

		public UI_PanelShop()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_frame = (GLabel)this.GetChildAt(0);
			m_LabelTotalVisitorCount = (GTextField)this.GetChildAt(1);
			m_LabelTotalIncome = (GTextField)this.GetChildAt(2);
			m_LabelInPrice = (GTextField)this.GetChildAt(3);
			m_LabelOutPrice = (GTextField)this.GetChildAt(4);
			m_LabelTax = (GTextField)this.GetChildAt(5);
			m_LabelIncome = (GTextField)this.GetChildAt(6);
			m_LabelVisitorCount = (GTextField)this.GetChildAt(9);
			m_LoaderIcon = (GLoader)this.GetChildAt(10);
			m_BtnCancel = (GButton)this.GetChildAt(11);
			m_BtnSetting = (GButton)this.GetChildAt(12);
			m_BtnJump = (GComponent)this.GetChildAt(13);
		}
	}
}