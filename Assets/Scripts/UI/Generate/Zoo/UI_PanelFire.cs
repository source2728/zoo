/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelFire : GComponent
	{
		public GLabel m_frame;
		public GLoader m_LoaderIcon;
		public GTextField m_LabelContent;
		public GButton m_BtnEnter;
		public GTextField m_LabelCost;

		public const string URL = "ui://5voe50hlf8pi4d";

		public static UI_PanelFire CreateInstance()
		{
			return (UI_PanelFire)UIPackage.CreateObject("Zoo","PanelFire");
		}

		public UI_PanelFire()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_frame = (GLabel)this.GetChildAt(0);
			m_LoaderIcon = (GLoader)this.GetChildAt(1);
			m_LabelContent = (GTextField)this.GetChildAt(2);
			m_BtnEnter = (GButton)this.GetChildAt(4);
			m_LabelCost = (GTextField)this.GetChildAt(5);
		}
	}
}