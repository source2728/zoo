/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_PanelFrameDialog : GLabel
	{
		public GButton m_BtnEnter;

		public const string URL = "ui://v24iwrrelho76s";

		public static UI_PanelFrameDialog CreateInstance()
		{
			return (UI_PanelFrameDialog)UIPackage.CreateObject("Common","PanelFrameDialog");
		}

		public UI_PanelFrameDialog()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BtnEnter = (GButton)this.GetChildAt(2);
		}
	}
}