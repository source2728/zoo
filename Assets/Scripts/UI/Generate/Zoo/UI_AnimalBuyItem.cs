/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_AnimalBuyItem : GComponent
	{
		public GLoader m_LoaderIcon;
		public GTextField m_LabelName;
		public GTextField m_LabelMoney;

		public const string URL = "ui://5voe50hllkym9w";

		public static UI_AnimalBuyItem CreateInstance()
		{
			return (UI_AnimalBuyItem)UIPackage.CreateObject("Zoo","AnimalBuyItem");
		}

		public UI_AnimalBuyItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LoaderIcon = (GLoader)this.GetChildAt(1);
			m_LabelName = (GTextField)this.GetChildAt(2);
			m_LabelMoney = (GTextField)this.GetChildAt(4);
		}
	}
}