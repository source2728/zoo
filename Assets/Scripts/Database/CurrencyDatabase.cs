using System.Collections.Generic;
using UnityEngine;

public class CurrencyDatabase : BaseDatabase
{
    private Dictionary<int, int> m_CurrencyMap = new Dictionary<int, int>();

    public override void ClearData()
    {
        m_CurrencyMap.Clear();
    }

    public override void LoadDataFromJson(string json)
    {
        m_CurrencyMap = JsonUtility.FromJson<Serialization<int, int>>(json).ToDictionary();
    }

    public override void LoadDataFromDefault(DefaultLocalData data)
    {
        SetCurrencyValue(ECurrencyType.Gold, data.Money);
    }

    public override string SaveDataAsJson()
    {
        return JsonUtility.ToJson(new Serialization<int, int>(m_CurrencyMap));
    }

    public int GetCurrencyValue(int type)
    {
        int value = 0;
        m_CurrencyMap.TryGetValue(type, out value);
        return value;
    }

    public int GetCurrencyValue(ECurrencyType type)
    {
        return GetCurrencyValue((int) type);
    }

    public void SetCurrencyValue(int type, int value)
    {
        IsDirty = true;
        if (m_CurrencyMap.ContainsKey(type))
        {
            m_CurrencyMap[type] = value;
        }
        else
        {
            m_CurrencyMap.Add(type, value);
        }
    }

    public void SetCurrencyValue(ECurrencyType type, int value)
    {
        SetCurrencyValue((int)type, value);
    }

    public void AddCurrencyValue(ECurrencyType type, int addValue)
    {
        SetCurrencyValue(type, GetCurrencyValue(type) + addValue);
    }
}