/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelZooSetting : GComponent
	{
		public GLabel m_frame;
		public GButton m_BtnCancel;
		public GButton m_BtnSetting;
		public GLabel m_LabelPrice;
		public GButton m_BtnPlus;
		public GButton m_BtnMinus;

		public const string URL = "ui://5voe50hlcn2c99";

		public static UI_PanelZooSetting CreateInstance()
		{
			return (UI_PanelZooSetting)UIPackage.CreateObject("Zoo","PanelZooSetting");
		}

		public UI_PanelZooSetting()
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
		}
	}
}