/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_ItemFenceAreaBuild : GButton
	{
		public GLoader m_LoaderIcon;
		public GTextField m_LabelName;

		public const string URL = "ui://5voe50hlpsmyan";

		public static UI_ItemFenceAreaBuild CreateInstance()
		{
			return (UI_ItemFenceAreaBuild)UIPackage.CreateObject("Zoo","ItemFenceAreaBuild");
		}

		public UI_ItemFenceAreaBuild()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LoaderIcon = (GLoader)this.GetChildAt(1);
			m_LabelName = (GTextField)this.GetChildAt(2);
		}
	}
}