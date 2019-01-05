/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelRename : GComponent
	{
		public GLabel m_frame;
		public GButton m_BtnEnter;
		public GLabel m_InputName;
		public GTextField m_LabelCost;

		public const string URL = "ui://5voe50hlot3g5y";

		public static UI_PanelRename CreateInstance()
		{
			return (UI_PanelRename)UIPackage.CreateObject("Zoo","PanelRename");
		}

		public UI_PanelRename()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_frame = (GLabel)this.GetChildAt(0);
			m_BtnEnter = (GButton)this.GetChildAt(2);
			m_InputName = (GLabel)this.GetChildAt(3);
			m_LabelCost = (GTextField)this.GetChildAt(4);
		}
	}
}