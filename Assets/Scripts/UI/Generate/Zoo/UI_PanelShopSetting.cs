/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelShopSetting : GComponent
	{
		public GLabel m_frame;
		public GButton m_BtnCancel;
		public GButton m_BtnSetting;
		public GLabel m_LabelPrice;
		public GButton m_BtnPlus;
		public GButton m_BtnMinus;
		public GComponent m_BtnPointToScene;

		public const string URL = "ui://5voe50hle9494y";

		public static UI_PanelShopSetting CreateInstance()
		{
			return (UI_PanelShopSetting)UIPackage.CreateObject("Zoo","PanelShopSetting");
		}

		public UI_PanelShopSetting()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_frame = (GLabel)this.GetChildAt(0);
			m_BtnCancel = (GButton)this.GetChildAt(3);
			m_BtnSetting = (GButton)this.GetChildAt(4);
			m_LabelPrice = (GLabel)this.GetChildAt(5);
			m_BtnPlus = (GButton)this.GetChildAt(6);
			m_BtnMinus = (GButton)this.GetChildAt(7);
			m_BtnPointToScene = (GComponent)this.GetChildAt(8);
		}
	}
}