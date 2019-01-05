/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_SceneOpt : GComponent
	{
		public GButton m_BtnRestore;
		public GButton m_BtnRotation;

		public const string URL = "ui://5voe50hlnmuh9j";

		public static UI_SceneOpt CreateInstance()
		{
			return (UI_SceneOpt)UIPackage.CreateObject("Zoo","SceneOpt");
		}

		public UI_SceneOpt()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BtnRestore = (GButton)this.GetChildAt(0);
			m_BtnRotation = (GButton)this.GetChildAt(1);
		}
	}
}