/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_List01 : GComponent
	{
		public Controller m_LockState;
		public GTextField m_LabelName;
		public GTextField m_LabelUnlockCost;

		public const string URL = "ui://5voe50hla1q28q";

		public static UI_List01 CreateInstance()
		{
			return (UI_List01)UIPackage.CreateObject("Zoo","List01");
		}

		public UI_List01()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LockState = this.GetControllerAt(0);
			m_LabelName = (GTextField)this.GetChildAt(2);
			m_LabelUnlockCost = (GTextField)this.GetChildAt(4);
		}
	}
}