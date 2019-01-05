using System;
using System.Reflection;
using Common;
using FairyGUI;
using UnityGameFramework.Runtime;
using Zoo;

public static class UIExtension
{
    public static void OpenUIForm<T>(this UIComponent uiComponent, object userData = null)
    {
        var type = typeof(T);
        var url = type.GetField("URL", BindingFlags.Static | BindingFlags.Public).GetValue(type).ToString();
        uiComponent.OpenUIForm(url, "Default", 0, true, userData);
    }

    public static void ShowTips(this UIComponent uiComponent, string content)
    {
        var tips = UI_CommonTips.CreateInstance();
        tips.title = content;
        GRoot.inst.AddChild(tips);
        tips.Center();

        tips.TweenMoveY(tips.position.y - 50, 1f)
            .OnComplete((() =>
                    {
                        tips.TweenFade(0, 0.15f).OnComplete((() =>
                        {
                            tips.Dispose();
                        }));
                    }
                ));
    }

    public static void ShowSecretaryTips(this UIComponent uiComponent, string content)
    {
        var tips = UI_SecretaryTips.CreateInstance();
        tips.title = content;
        GRoot.inst.AddChild(tips);
        tips.Center();

        tips.TweenMoveY(tips.position.y - 50, 1f)
            .OnComplete((() =>
                    {
                        tips.TweenFade(0, 0.15f).OnComplete((() =>
                        {
                            tips.Dispose();
                        }));
                    }
                ));
    }
}
