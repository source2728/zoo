/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_PanelTotalInfo : GComponent
	{
		public Controller m_ViewState;
		public GLabel m_frame;
		public UI_TabActorInfo m_TabActorInfo;
		public UI_TabSecretaryInfo m_TabSecretaryInfo;
		public UI_TabGuardInfo m_TabGuardInfo;
		public UI_TabZooInfo m_TabZooInfo;

		public const string URL = "ui://5voe50hlot3g50";

		public static UI_PanelTotalInfo CreateInstance()
		{
			return (UI_PanelTotalInfo)UIPackage.CreateObject("Zoo","PanelTotalInfo");
		}

		public UI_PanelTotalInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_frame = (GLabel)this.GetChildAt(0);
			m_TabActorInfo = (UI_TabActorInfo)this.GetChildAt(7);
			m_TabSecretaryInfo = (UI_TabSecretaryInfo)this.GetChildAt(8);
			m_TabGuardInfo = (UI_TabGuardInfo)this.GetChildAt(9);
			m_TabZooInfo = (UI_TabZooInfo)this.GetChildAt(10);
		}
	}
}