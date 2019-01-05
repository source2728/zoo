/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_TabActorInfo : GComponent
	{
		public GTextField m_LabelHonor;
		public GTextField m_LabelIncomeBonus;
		public GTextField m_LabelMoney;
		public GComponent m_StarLevel;
		public GButton m_BtnRename;
		public GTextField m_LabelName;

		public const string URL = "ui://5voe50hlot3g5k";

		public static UI_TabActorInfo CreateInstance()
		{
			return (UI_TabActorInfo)UIPackage.CreateObject("Zoo","TabActorInfo");
		}

		public UI_TabActorInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelHonor = (GTextField)this.GetChildAt(1);
			m_LabelIncomeBonus = (GTextField)this.GetChildAt(4);
			m_LabelMoney = (GTextField)this.GetChildAt(5);
			m_StarLevel = (GComponent)this.GetChildAt(7);
			m_BtnRename = (GButton)this.GetChildAt(10);
			m_LabelName = (GTextField)this.GetChildAt(11);
		}
	}
}