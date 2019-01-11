/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_FilletBig : GButton
	{
		public GLoader m_LoaderIcon;
		public GTextField m_LabelCost;

		public const string URL = "ui://5voe50hll9uh1y";

		public static UI_FilletBig CreateInstance()
		{
			return (UI_FilletBig)UIPackage.CreateObject("Zoo","FilletBig");
		}

		public UI_FilletBig()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LoaderIcon = (GLoader)this.GetChildAt(1);
			m_LabelCost = (GTextField)this.GetChildAt(2);
		}
	}
}