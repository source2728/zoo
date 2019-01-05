/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelHandbook : GComponent
	{
		public Controller m_MainType;
		public Controller m_FacilityType;
		public GLabel m_frame;
		public GList m_List;

		public const string URL = "ui://5voe50hla1q27l";

		public static UI_PanelHandbook CreateInstance()
		{
			return (UI_PanelHandbook)UIPackage.CreateObject("Zoo","PanelHandbook");
		}

		public UI_PanelHandbook()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_MainType = this.GetControllerAt(0);
			m_FacilityType = this.GetControllerAt(1);
			m_frame = (GLabel)this.GetChildAt(0);
			m_List = (GList)this.GetChildAt(6);
		}
	}
}