/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelDamageTips : GComponent
	{
		public GButton m_BtnCancel;

		public const string URL = "ui://5voe50hlbhgzo";

		public static UI_PanelDamageTips CreateInstance()
		{
			return (UI_PanelDamageTips)UIPackage.CreateObject("Zoo","PanelDamageTips");
		}

		public UI_PanelDamageTips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BtnCancel = (GButton)this.GetChildAt(5);
		}
	}
}