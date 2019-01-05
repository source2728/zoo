/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_CommonTips : GLabel
	{
		public GImage m_Frame;

		public const string URL = "ui://v24iwrre108ho5i";

		public static UI_CommonTips CreateInstance()
		{
			return (UI_CommonTips)UIPackage.CreateObject("Common","CommonTips");
		}

		public UI_CommonTips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Frame = (GImage)this.GetChildAt(0);
		}
	}
}