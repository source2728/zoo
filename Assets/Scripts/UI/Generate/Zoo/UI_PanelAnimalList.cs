/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelAnimalList : GComponent
	{
		public Controller m_ViewState;
		public GLabel m_frame;
		public GComponent m_BtnJump;
		public GList m_TypeList;
		public GLoader m_LoaderIcon;
		public GList m_AttrList;
		public GList m_ListBuyItem;
		public GGroup m_GroupBuy;

		public const string URL = "ui://5voe50hlybae2j";

		public static UI_PanelAnimalList CreateInstance()
		{
			return (UI_PanelAnimalList)UIPackage.CreateObject("Zoo","PanelAnimalList");
		}

		public UI_PanelAnimalList()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_frame = (GLabel)this.GetChildAt(0);
			m_BtnJump = (GComponent)this.GetChildAt(1);
			m_TypeList = (GList)this.GetChildAt(2);
			m_LoaderIcon = (GLoader)this.GetChildAt(3);
			m_AttrList = (GList)this.GetChildAt(4);
			m_ListBuyItem = (GList)this.GetChildAt(7);
			m_GroupBuy = (GGroup)this.GetChildAt(8);
		}
	}
}