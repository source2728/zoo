/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_Event01 : GComponent
	{
		public GTextField m_LabelContent;

		public const string URL = "ui://5voe50hly7v678";

		public static UI_Event01 CreateInstance()
		{
			return (UI_Event01)UIPackage.CreateObject("Zoo","Event01");
		}

		public UI_Event01()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelContent = (GTextField)this.GetChildAt(1);
		}
	}
}