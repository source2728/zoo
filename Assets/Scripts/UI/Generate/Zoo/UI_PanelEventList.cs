/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelEventList : GComponent
	{
		public GLabel m_frame;
		public GList m_List;

		public const string URL = "ui://5voe50hl8hmy6x";

		public static UI_PanelEventList CreateInstance()
		{
			return (UI_PanelEventList)UIPackage.CreateObject("Zoo","PanelEventList");
		}

		public UI_PanelEventList()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_frame = (GLabel)this.GetChildAt(0);
			m_List = (GList)this.GetChildAt(2);
		}
	}
}