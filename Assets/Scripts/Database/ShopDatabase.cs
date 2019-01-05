using System.Collections.Generic;
using UnityEngine;

public class ShopDatabase : BaseDatabase
{
    protected List<ShopData> m_ShopList = new List<ShopData>();
    public List<ShopData> ShopList
    {
        get { return m_ShopList; }
    }

    public int UniqueId = 0;

    public override void ClearData()
    {
        m_ShopList.Clear();
        UniqueId = 0;
    }

    public override void LoadDataFromJson(string json)
    {
        m_ShopList = JsonUtility.FromJson<Serialization<ShopData>>(json).ToList();
        foreach (var staff in m_ShopList)
        {
            if (staff.Uid > UniqueId)
            {
                UniqueId = staff.Uid;
            }
        }
    }

    public override void LoadDataFromDefault(DefaultLocalData data)
    {
    }

    public override string SaveDataAsJson()
    {
        return JsonUtility.ToJson(new Serialization<ShopData>(m_ShopList));
    }

    public void AddShop(ShopData data)
    {
        IsDirty = true;
        data.Uid = ++UniqueId;
        m_ShopList.Add(data);
    }

    public void RemoveShop(int uid)
    {
        IsDirty = true;
        foreach (var shop in m_ShopList)
        {
            if (shop.Uid == uid)
            {
                m_ShopList.Remove(shop);
                break;
            }
        }
    }

    public void UpdateShop(int uid, Vector2Int postion, float rotation)
    {
        IsDirty = true;
        foreach (var shop in m_ShopList)
        {
            if (shop.Uid == uid)
            {
                shop.LeftBottom.x = postion.x;
                shop.LeftBottom.y = postion.y;
                shop.Rotation = rotation;
                break;
            }
        }
    }

    public ShopData GetShop(int uid)
    {
        foreach (var shop in m_ShopList)
        {
            if (shop.Uid == uid)
            {
                return shop;
            }
        }

        return null;
    }
}