/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_Event02 : GComponent
	{
		public GTextField m_LabelContent;

		public const string URL = "ui://5voe50hltzsx79";

		public static UI_Event02 CreateInstance()
		{
			return (UI_Event02)UIPackage.CreateObject("Zoo","Event02");
		}

		public UI_Event02()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelContent = (GTextField)this.GetChildAt(1);
		}
	}
}