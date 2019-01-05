/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_StaffItem : GComponent
	{
		public GButton m_BtnFire;
		public GTextField m_LabelName;

		public const string URL = "ui://5voe50hlm9ss97";

		public static UI_StaffItem CreateInstance()
		{
			return (UI_StaffItem)UIPackage.CreateObject("Zoo","StaffItem");
		}

		public UI_StaffItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BtnFire = (GButton)this.GetChildAt(1);
			m_LabelName = (GTextField)this.GetChildAt(2);
		}
	}
}