/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_TabZooInfo : GComponent
	{
		public GTextField m_LabelVisitor;
		public GTextField m_LabelMoney;
		public GComponent m_StarLevelPopular;
		public GComponent m_StarLevelLike;
		public GTextField m_LabelIncome;
		public GTextField m_LabelPrice;
		public GButton m_BtnSettingPrice;
		public GButton m_BtnRename;
		public GTextField m_LabelName;

		public const string URL = "ui://5voe50hlot3g5q";

		public static UI_TabZooInfo CreateInstance()
		{
			return (UI_TabZooInfo)UIPackage.CreateObject("Zoo","TabZooInfo");
		}

		public UI_TabZooInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelVisitor = (GTextField)this.GetChildAt(3);
			m_LabelMoney = (GTextField)this.GetChildAt(4);
			m_StarLevelPopular = (GComponent)this.GetChildAt(7);
			m_StarLevelLike = (GComponent)this.GetChildAt(8);
			m_LabelIncome = (GTextField)this.GetChildAt(12);
			m_LabelPrice = (GTextField)this.GetChildAt(15);
			m_BtnSettingPrice = (GButton)this.GetChildAt(17);
			m_BtnRename = (GButton)this.GetChildAt(18);
			m_LabelName = (GTextField)this.GetChildAt(19);
		}
	}
}