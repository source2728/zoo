using DataTable;
using Zoo;
public class UIPanelEventList : UIFormWin
{
	public UI_PanelEventList UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelEventList;
	}

    protected override void DoShown(object userData)
    {
        UI.m_List.RemoveChildrenToPool(0, UI.m_List.numItems);
        foreach (var evt in GameEntry.Database.Event.EventList)
        {
            var deploy = GameEntry.DataTable.GetDataTableRow<DREvent>(evt);
//            if (evt == 1)
//            {
//                var item = UI.m_List.GetFromPool(UI_Event01.URL) as UI_Event01;
//                item.m_LabelContent.SetText(deploy.Content);
//                UI.m_List.AddChild(item);
//            }
//            else if (evt == 2)
//            {
//                var item = UI.m_List.GetFromPool(UI_Event02.URL) as UI_Event02;
//                item.m_LabelContent.SetText(deploy.Content);
//                UI.m_List.AddChild(item);
//            }
//            else if (evt == 3)
//            {
//                var item = UI.m_List.GetFromPool(UI_Event03.URL) as UI_Event03;
//                item.m_LabelContent.SetText(deploy.Content);
//                UI.m_List.AddChild(item);
//            }

            var item = UI.m_List.GetFromPool(UI_Event01.URL) as UI_Event01;
            item.m_LabelContent.SetText(deploy.Content);
            UI.m_List.AddChild(item);
        }
    }

    protected override void DoRefresh(object userData)
	{

	}
}
