/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_ModalLayer : GComponent
	{
		public GGraph m_Layer;

		public const string URL = "ui://v24iwrreuji05h";

		public static UI_ModalLayer CreateInstance()
		{
			return (UI_ModalLayer)UIPackage.CreateObject("Common","ModalLayer");
		}

		public UI_ModalLayer()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Layer = (GGraph)this.GetChildAt(0);
		}
	}
}