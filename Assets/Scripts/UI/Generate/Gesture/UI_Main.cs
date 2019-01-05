/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Gesture
{
	public partial class UI_Main : GComponent
	{
		public GGraph m_holder;

		public const string URL = "ui://kf09pe2q109590";

		public static UI_Main CreateInstance()
		{
			return (UI_Main)UIPackage.CreateObject("Gesture","Main");
		}

		public UI_Main()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_holder = (GGraph)this.GetChildAt(0);
		}
	}
}