using System;

namespace UnityGameFramework.Runtime
{
    public interface IUIFormLogic
    {
        void OnInit(object userData);
        void OnOpen(object userData);
        void OnClose(object userData);
        void OnPause();
        void OnResume();
        void OnCover();
        void OnReveal();
        void OnRefocus(object userData);
        void OnUpdate(float elapseSeconds, float realElapseSeconds);
        void OnDepthChanged(int uiGroupDepth, int depthInUIGroup);
    }
}
