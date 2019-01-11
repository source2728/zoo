/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_Event03 : GComponent
	{
		public GTextField m_LabelContent;

		public const string URL = "ui://5voe50hltzsx7a";

		public static UI_Event03 CreateInstance()
		{
			return (UI_Event03)UIPackage.CreateObject("Zoo","Event03");
		}

		public UI_Event03()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelContent = (GTextField)this.GetChildAt(1);
		}
	}
}