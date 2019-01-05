/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_StarLevel : GComponent
	{
		public Controller m_Level;

		public const string URL = "ui://v24iwrrehc5m68";

		public static UI_StarLevel CreateInstance()
		{
			return (UI_StarLevel)UIPackage.CreateObject("Common","StarLevel");
		}

		public UI_StarLevel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Level = this.GetControllerAt(0);
		}
	}
}