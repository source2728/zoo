/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelTips : GComponent
	{
		public GButton m_BtnCancel;

		public const string URL = "ui://5voe50hll9uh2a";

		public static UI_PanelTips CreateInstance()
		{
			return (UI_PanelTips)UIPackage.CreateObject("Zoo","PanelTips");
		}

		public UI_PanelTips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BtnCancel = (GButton)this.GetChildAt(3);
		}
	}
}