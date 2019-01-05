/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelIncomDetail : GComponent
	{
		public GLabel m_frame;
		public GTextField m_LabelDayIncome;

		public const string URL = "ui://5voe50hlgkwa7b";

		public static UI_PanelIncomDetail CreateInstance()
		{
			return (UI_PanelIncomDetail)UIPackage.CreateObject("Zoo","PanelIncomDetail");
		}

		public UI_PanelIncomDetail()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_frame = (GLabel)this.GetChildAt(0);
			m_LabelDayIncome = (GTextField)this.GetChildAt(3);
		}
	}
}