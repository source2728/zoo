/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelZooInfo : GComponent
	{
		public GLabel m_frame;
		public GList m_List;

		public const string URL = "ui://5voe50hlvocx35";

		public static UI_PanelZooInfo CreateInstance()
		{
			return (UI_PanelZooInfo)UIPackage.CreateObject("Zoo","PanelZooInfo");
		}

		public UI_PanelZooInfo()
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