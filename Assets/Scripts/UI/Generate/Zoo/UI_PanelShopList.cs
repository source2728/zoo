/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelShopList : GComponent
	{
		public GLabel m_frame;
		public GList m_List;

		public const string URL = "ui://5voe50hlvwoe3t";

		public static UI_PanelShopList CreateInstance()
		{
			return (UI_PanelShopList)UIPackage.CreateObject("Zoo","PanelShopList");
		}

		public UI_PanelShopList()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_frame = (GLabel)this.GetChildAt(0);
			m_List = (GList)this.GetChildAt(1);
		}
	}
}