/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_Zoo : GButton
	{
		public GLoader m_LoaderIcon;

		public const string URL = "ui://5voe50hlvocx3c";

		public static UI_Zoo CreateInstance()
		{
			return (UI_Zoo)UIPackage.CreateObject("Zoo","Zoo");
		}

		public UI_Zoo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LoaderIcon = (GLoader)this.GetChildAt(1);
		}
	}
}