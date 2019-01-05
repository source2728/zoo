/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelAnimalList : GComponent
	{
		public GLabel m_frame;
		public GList m_TypeList;
		public GList m_AttrList;

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

			m_frame = (GLabel)this.GetChildAt(0);
			m_TypeList = (GList)this.GetChildAt(3);
			m_AttrList = (GList)this.GetChildAt(4);
		}
	}
}