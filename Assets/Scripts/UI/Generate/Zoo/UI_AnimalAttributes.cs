/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_AnimalAttributes : GComponent
	{
		public Controller m_ViewState;
		public GLoader m_LoaderIcon;
		public GTextField m_LabelName;
		public GTextField m_LabelAttr1;
		public GTextField m_LabelAttr2;
		public GTextField m_LabelAttr3;
		public GTextField m_LabelAttr4;
		public GButton m_BtnRemove;
		public GGroup m_GroupInfo;

		public const string URL = "ui://5voe50hlybae34";

		public static UI_AnimalAttributes CreateInstance()
		{
			return (UI_AnimalAttributes)UIPackage.CreateObject("Zoo","AnimalAttributes");
		}

		public UI_AnimalAttributes()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_LoaderIcon = (GLoader)this.GetChildAt(1);
			m_LabelName = (GTextField)this.GetChildAt(2);
			m_LabelAttr1 = (GTextField)this.GetChildAt(3);
			m_LabelAttr2 = (GTextField)this.GetChildAt(4);
			m_LabelAttr3 = (GTextField)this.GetChildAt(5);
			m_LabelAttr4 = (GTextField)this.GetChildAt(6);
			m_BtnRemove = (GButton)this.GetChildAt(7);
			m_GroupInfo = (GGroup)this.GetChildAt(8);
		}
	}
}