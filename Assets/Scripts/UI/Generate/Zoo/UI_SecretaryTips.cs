/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_SecretaryTips : GLabel
	{
		public GImage m_IconTips;

		public const string URL = "ui://5voe50hl929s6t";

		public static UI_SecretaryTips CreateInstance()
		{
			return (UI_SecretaryTips)UIPackage.CreateObject("Zoo","SecretaryTips");
		}

		public UI_SecretaryTips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_IconTips = (GImage)this.GetChildAt(2);
		}
	}
}