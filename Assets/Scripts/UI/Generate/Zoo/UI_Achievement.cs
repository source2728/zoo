/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_Achievement : GLabel
	{
		public GImage m_icon1;

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

			m_icon1 = (GImage)this.GetChildAt(3);
		}
	}
}