/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_Shop : GButton
	{
		public GLoader m_LoaderIcon;
		public GTextField m_LabelName;
		public GTextField m_LabelIncome;
		public GTextField m_LabelVisitorCount;

		public const string URL = "ui://5voe50hlvwoe4c";

		public static UI_Shop CreateInstance()
		{
			return (UI_Shop)UIPackage.CreateObject("Zoo","Shop");
		}

		public UI_Shop()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LoaderIcon = (GLoader)this.GetChildAt(1);
			m_LabelName = (GTextField)this.GetChildAt(2);
			m_LabelIncome = (GTextField)this.GetChildAt(4);
			m_LabelVisitorCount = (GTextField)this.GetChildAt(5);
		}
	}
}