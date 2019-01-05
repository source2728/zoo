/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_PanelFrameWithTitleAndClose : GLabel
	{
		public GButton m_closeButton;

		public const string URL = "ui://v24iwrrek16wo5o";

		public static UI_PanelFrameWithTitleAndClose CreateInstance()
		{
			return (UI_PanelFrameWithTitleAndClose)UIPackage.CreateObject("Common","PanelFrameWithTitleAndClose");
		}

		public UI_PanelFrameWithTitleAndClose()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_closeButton = (GButton)this.GetChildAt(2);
		}
	}
}