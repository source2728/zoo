/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelRecruitStaff : GComponent
	{
		public GLabel m_frame;
		public GList m_List;

		public const string URL = "ui://5voe50hlxcbo4z";

		public static UI_PanelRecruitStaff CreateInstance()
		{
			return (UI_PanelRecruitStaff)UIPackage.CreateObject("Zoo","PanelRecruitStaff");
		}

		public UI_PanelRecruitStaff()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_frame = (GLabel)this.GetChildAt(0);
			m_List = (GList)this.GetChildAt(1);
		}
	}
}