/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelAchievement : GComponent
	{
		public GLabel m_frame;

		public const string URL = "ui://5voe50hlbfqc3d";

		public static UI_PanelAchievement CreateInstance()
		{
			return (UI_PanelAchievement)UIPackage.CreateObject("Zoo","PanelAchievement");
		}

		public UI_PanelAchievement()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_frame = (GLabel)this.GetChildAt(0);
		}
	}
}