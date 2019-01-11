/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Zoo
{
	public partial class UI_AnimalQuantity : GComponent
	{
		public GTextField m_LabelCount;
		public GLoader m_LoaderIcon;

		public const string URL = "ui://5voe50hlybae33";

		public static UI_AnimalQuantity CreateInstance()
		{
			return (UI_AnimalQuantity)UIPackage.CreateObject("Zoo","AnimalQuantity");
		}

		public UI_AnimalQuantity()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelCount = (GTextField)this.GetChildAt(1);
			m_LoaderIcon = (GLoader)this.GetChildAt(2);
		}
	}
}