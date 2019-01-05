using System;
using Common;
using FairyGUI;
using GameFramework.UI;
using UnityGameFramework.Runtime;
using Zoo;

public class FGuiFormHelper : UIFormHelperBase
{
    public override IUIForm CreateUIForm(object uiFormInstance, IUIGroup uiGroup, object userData)
    {
        return uiFormInstance as IUIForm;
    }

    public override object InstantiateUIForm(object uiFormAsset)
    {
        var uiFormInstance = UIPackage.CreateObjectFromURL(uiFormAsset.ToString());
        Type uiType = uiFormInstance.GetType();
        var uiLogicClassName = uiType.Name.Replace("_", "");
        Type uiLogicType = Type.GetType(uiLogicClassName);
        UIFormWin win = Activator.CreateInstance(uiLogicType) as UIFormWin;
        win.contentPane = uiFormInstance as GComponent;
        return win;
    }

    public override void ReleaseUIForm(object uiFormAsset, object uiFormInstance)
    {
    }
}
