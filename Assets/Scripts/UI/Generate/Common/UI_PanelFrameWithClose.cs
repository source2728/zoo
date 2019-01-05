/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_PanelFrameWithClose : GLabel
	{
		public GButton m_closeButton;

		public const string URL = "ui://v24iwrreot3g5g";

		public static UI_PanelFrameWithClose CreateInstance()
		{
			return (UI_PanelFrameWithClose)UIPackage.CreateObject("Common","PanelFrameWithClose");
		}

		public UI_PanelFrameWithClose()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_closeButton = (GButton)this.GetChildAt(1);
		}
	}
}