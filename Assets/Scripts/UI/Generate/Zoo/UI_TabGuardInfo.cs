/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_TabGuardInfo : GComponent
	{
		public GLabel m_LabelDialog;
		public GButton m_BtnRename;
		public GTextField m_LabelName;

		public const string URL = "ui://5voe50hlot3g5i";

		public static UI_TabGuardInfo CreateInstance()
		{
			return (UI_TabGuardInfo)UIPackage.CreateObject("Zoo","TabGuardInfo");
		}

		public UI_TabGuardInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelDialog = (GLabel)this.GetChildAt(0);
			m_BtnRename = (GButton)this.GetChildAt(1);
			m_LabelName = (GTextField)this.GetChildAt(2);
		}
	}
}