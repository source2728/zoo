using System;
using DataTable;
using FairyGUI;
using Zoo;
public class UIPanelHandbook : UIFormWin
{
	public UI_PanelHandbook UI { get; private set; }

	protected override void OnInit()
	{
		base.OnInit();
		UI = contentPane as UI_PanelHandbook;
        UI.m_MainType.onChanged.Set(OnChangeMainType);
	    UI.m_FacilityType.onChanged.Set(OnChangeFacilityType);
        UI.m_List.itemRenderer = OnItemRenderer;
	}

    protected override void DoShown(object userData)
    {
        UI.m_MainType.selectedIndex = 1;
    }

    protected override void DoRefresh(object userData)
	{

	}

    private void OnChangeMainType()
    {
        switch (UI.m_MainType.selectedIndex)
        {
            case 1:
                UI.m_List.SetData(GameEntry.DataTable.GetDataTable<DRAnimal>().GetAllDataRows());
                break;

            case 2:
                UI.m_List.SetData(GameEntry.DataTable.GetDataTable<DRFacility>().GetDataRows(OnSelectFacilityType));
                break;

            case 3:
                UI.m_List.SetData(GameEntry.DataTable.GetDataTable<DRLand>().GetAllDataRows());
                break;

            case 4:
                UI.m_List.SetData(GameEntry.DataTable.GetDataTable<DRFence>().GetAllDataRows());
                break;
        }
    }

    private void OnChangeFacilityType()
    {
        UI.m_List.SetData(GameEntry.DataTable.GetDataTable<DRFacility>().GetDataRows(OnSelectFacilityType));
    }

    private bool OnSelectFacilityType(DRFacility obj)
    {
        return obj.Type == UI.m_FacilityType.selectedIndex;
    }

    private void OnItemRenderer(int index, GObject obj)
    {
        var item = obj as UI_List01;
        switch (UI.m_MainType.selectedIndex)
        {
            case 1:
            {
                DRAnimal deploy = UI.m_List.GetData<DRAnimal>(index);
                item.m_LabelName.SetText(deploy.Name);
            }
                break;

            case 2:
            {
                DRFacility deploy = UI.m_List.GetData<DRFacility>(index);
                item.m_LabelName.SetText(deploy.Name);
            }
                break;

            case 3:
            {
                DRLand deploy = UI.m_List.GetData<DRLand>(index);
                item.m_LabelName.SetText(deploy.Name);
            }
                break;

            case 4:
            {
                DRFence deploy = UI.m_List.GetData<DRFence>(index);
                item.m_LabelName.SetText(deploy.Name);
            }
                break;
        }
        
    }
}
