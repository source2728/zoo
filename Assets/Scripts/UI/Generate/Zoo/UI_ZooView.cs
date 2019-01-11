/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_ZooView : GComponent
	{
		public Controller m_ViewState;
		public Controller m_BuildType;
		public Controller m_BuildButtonState;
		public Controller m_MainMenuState;
		public GList m_ListMenu;
		public GGroup m_Menu;
		public GTextField m_LabelVisitorCount;
		public GTextField m_LabelVisitorLike;
		public GTextField m_LabelIncome;
		public GTextField m_LabelMoney;
		public GButton m_BtnMenu;
		public GButton m_BtnCloseEdit;
		public GButton m_BtnEnterBuild;
		public GButton m_BtnUndo;
		public GList m_ListBuildItems;
		public GList m_ListBuildingObjects;
		public GGroup m_ComMenus;
		public GButton m_BtnResetData;
		public GList m_ListLand;
		public GList m_ListFence;
		public GGroup m_GroupFenceArea;
		public GList m_ListEditingObjects;
		public GButton m_BtnEnterEdit;
		public GGroup m_EditStatePanel;
		public GGroup m_GroupBuildButton;
		public GButton m_BtnHand;
		public GButton m_BtnLook;

		public const string URL = "ui://5voe50hlbhgz0";

		public static UI_ZooView CreateInstance()
		{
			return (UI_ZooView)UIPackage.CreateObject("Zoo","ZooView");
		}

		public UI_ZooView()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_BuildType = this.GetControllerAt(1);
			m_BuildButtonState = this.GetControllerAt(2);
			m_MainMenuState = this.GetControllerAt(3);
			m_ListMenu = (GList)this.GetChildAt(1);
			m_Menu = (GGroup)this.GetChildAt(2);
			m_LabelVisitorCount = (GTextField)this.GetChildAt(8);
			m_LabelVisitorLike = (GTextField)this.GetChildAt(9);
			m_LabelIncome = (GTextField)this.GetChildAt(10);
			m_LabelMoney = (GTextField)this.GetChildAt(11);
			m_BtnMenu = (GButton)this.GetChildAt(12);
			m_BtnCloseEdit = (GButton)this.GetChildAt(13);
			m_BtnEnterBuild = (GButton)this.GetChildAt(17);
			m_BtnUndo = (GButton)this.GetChildAt(18);
			m_ListBuildItems = (GList)this.GetChildAt(19);
			m_ListBuildingObjects = (GList)this.GetChildAt(20);
			m_ComMenus = (GGroup)this.GetChildAt(21);
			m_BtnResetData = (GButton)this.GetChildAt(22);
			m_ListLand = (GList)this.GetChildAt(27);
			m_ListFence = (GList)this.GetChildAt(28);
			m_GroupFenceArea = (GGroup)this.GetChildAt(29);
			m_ListEditingObjects = (GList)this.GetChildAt(31);
			m_BtnEnterEdit = (GButton)this.GetChildAt(32);
			m_EditStatePanel = (GGroup)this.GetChildAt(33);
			m_GroupBuildButton = (GGroup)this.GetChildAt(40);
			m_BtnHand = (GButton)this.GetChildAt(41);
			m_BtnLook = (GButton)this.GetChildAt(42);
		}
	}
}