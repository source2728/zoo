/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelStaffList : GComponent
	{
		public GLabel m_frame;
		public GList m_List;
		public GButton m_BtnRecruit;

		public const string URL = "ui://5voe50hlm9ss8s";

		public static UI_PanelStaffList CreateInstance()
		{
			return (UI_PanelStaffList)UIPackage.CreateObject("Zoo","PanelStaffList");
		}

		public UI_PanelStaffList()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_frame = (GLabel)this.GetChildAt(0);
			m_List = (GList)this.GetChildAt(1);
			m_BtnRecruit = (GButton)this.GetChildAt(2);
		}
	}
}