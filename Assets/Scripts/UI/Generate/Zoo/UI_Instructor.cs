/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_Instructor : GButton
	{
		public GTextField m_LabelCost;
		public GTextField m_LabelName;

		public const string URL = "ui://5voe50hlucni67";

		public static UI_Instructor CreateInstance()
		{
			return (UI_Instructor)UIPackage.CreateObject("Zoo","Instructor");
		}

		public UI_Instructor()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelCost = (GTextField)this.GetChildAt(1);
			m_LabelName = (GTextField)this.GetChildAt(3);
		}
	}
}