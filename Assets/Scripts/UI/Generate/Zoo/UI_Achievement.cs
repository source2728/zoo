/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_Achievement : GComponent
	{
		public GLoader m_icon;
		public GTextField m_title;
		public GImage m_icon_2;

		public const string URL = "ui://5voe50hlbfqc3r";

		public static UI_Achievement CreateInstance()
		{
			return (UI_Achievement)UIPackage.CreateObject("Zoo","Achievement");
		}

		public UI_Achievement()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_icon = (GLoader)this.GetChildAt(1);
			m_title = (GTextField)this.GetChildAt(2);
			m_icon_2 = (GImage)this.GetChildAt(3);
		}
	}
}