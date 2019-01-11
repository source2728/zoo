using Common;
using FairyGUI;
using GameFramework.Event;
using GameFramework.UI;
using System;
using UnityGameFramework.Runtime;

public class UIFormWin : Window, IUIForm
{
    public int SerialId { get; private set; }

    public string UIFormAssetName { get; private set; }

    public object Handle
    {
        get { return this; }
    }

    public IUIGroup UIGroup { get; private set; }

    public int DepthInUIGroup { get; private set; }

    public bool PauseCoveredUIForm { get; private set; }

    public object UserData { get; private set; }

    public void OnClose(object userData)
    {
        Hide();
        GameEntry.Event.Unsubscribe(EvtDataUpdated.EventId, OnEvtDataUpdated);
    }

    public void OnCover()
    {
    }

    public void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
    {
    }

    public void OnOpen(object userData)
    {
        UserData = userData;
        GameEntry.Event.Subscribe(EvtDataUpdated.EventId, OnEvtDataUpdated);
        Show();
    }

    private void OnEvtDataUpdated(object sender, GameEventArgs e)
    {
        DoRefresh(UserData);
    }

    protected virtual void DoShown(object userData)
    {

    }

    protected virtual void DoRefresh(object userData)
    {

    }

    public void OnPause()
    {
    }

    public void OnRefocus(object userData)
    {
    }

    public void OnResume()
    {
    }

    public void OnReveal()
    {
    }

    public void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
    }

    protected override void OnInit()
    {
        base.OnInit();

        contentPane.sortingOrder = 1;
        Center();

        Type uiType = GetType();
        if (uiType.Name.Contains("Panel"))
        {
            var layer = UI_ModalLayer.CreateInstance();
            AddChild(layer);
            layer.Center();
            layer.onClick.AddCapture((context => { Close(); }));
        }

        if (closeButton != null)
        {
            closeButton.onClick.Set(() => { Close(); });
        }
    }

    public void Close()
    {
        GameEntry.UI.CloseUIForm(this, UserData);
    }

    protected override void OnShown()
    {
        base.OnShown();
        DoShown(UserData);
        DoRefresh(UserData);
    }

    protected override void OnHide()
    {
        base.OnHide();
        DoHide(UserData);
    }

    protected virtual void DoHide(object userData)
    {
    }

    protected override void DoShowAnimation()
    {
        base.DoShowAnimation();
    }

    protected override void DoHideAnimation()
    {
        base.DoHideAnimation();
    }

    public void OnInit(int serialId, string uiFormAssetName, IUIGroup uiGroup, bool pauseCoveredUIForm, bool isNewInstance, object userData)
    {
        UserData = userData;
        SerialId = serialId;
        UIFormAssetName = uiFormAssetName;
        if (isNewInstance)
        {
            UIGroup = uiGroup;
        }
        else if (UIGroup != uiGroup)
        {
            Log.Error("UI group is inconsistent for non-new-instance UI form.");
            return;
        }

        DepthInUIGroup = 0;
        PauseCoveredUIForm = pauseCoveredUIForm;
    }

    public void OnRecycle()
    {
        SerialId = 0;
        DepthInUIGroup = 0;
        PauseCoveredUIForm = true;
    }
}
