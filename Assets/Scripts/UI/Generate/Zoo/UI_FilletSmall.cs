/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_FilletSmall : GLabel
	{
		public GLoader m_LoaderIcon;
		public GTextField m_LabelMoney;
		public GTextField m_LabelCount;

		public const string URL = "ui://5voe50hll9uh2i";

		public static UI_FilletSmall CreateInstance()
		{
			return (UI_FilletSmall)UIPackage.CreateObject("Zoo","FilletSmall");
		}

		public UI_FilletSmall()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LoaderIcon = (GLoader)this.GetChildAt(1);
			m_LabelMoney = (GTextField)this.GetChildAt(2);
			m_LabelCount = (GTextField)this.GetChildAt(3);
		}
	}
}