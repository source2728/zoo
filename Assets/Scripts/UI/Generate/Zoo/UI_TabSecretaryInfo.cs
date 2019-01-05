/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_TabSecretaryInfo : GComponent
	{
		public GLabel m_LabelDialog;
		public GButton m_BtnRename;
		public GTextField m_LabelName;

		public const string URL = "ui://5voe50hlot3g5c";

		public static UI_TabSecretaryInfo CreateInstance()
		{
			return (UI_TabSecretaryInfo)UIPackage.CreateObject("Zoo","TabSecretaryInfo");
		}

		public UI_TabSecretaryInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelDialog = (GLabel)this.GetChildAt(1);
			m_BtnRename = (GButton)this.GetChildAt(2);
			m_LabelName = (GTextField)this.GetChildAt(3);
		}
	}
}