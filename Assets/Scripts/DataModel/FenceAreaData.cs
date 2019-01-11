using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class FenceAreaData
{
    public int Uid;
    public string Name;
    public List<Vector2Int> Fences = new List<Vector2Int>();
    public List<Vector2Int> AnimalCounts = new List<Vector2Int>();

    public bool HasGrid(int x, int y)
    {
        foreach (var fence in Fences)
        {
            if (fence.x == x && fence.y == y)
            {
                return true;
            }
        }

        return false;
    }

    protected readonly Vector2Int[] corners = new Vector2Int[]
    {
        new Vector2Int(0, 0), new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(1, 0),
    };

    public List<Vector2Int> GetFences()
    {
        List<Vector2Int> deleteList = new List<Vector2Int>();
        Dictionary<Vector2Int, int> map = new Dictionary<Vector2Int, int>();
        foreach (var fence in Fences)
        {
            foreach (var corner in corners)
            {
                var pos = fence + corner;
                if (map.ContainsKey(pos))
                {
                    map[pos]++;
                    if (map[pos] >= 4)
                    {
                        deleteList.Add(pos);
                    }
                }
                else
                {
                    map.Add(pos, 1);
                }
            }
        }
        foreach (var key in deleteList)
        {
            map.Remove(key);
        }
        return map.Keys.ToList();
    }

    protected readonly Vector2[] lines = new Vector2[]
    {
        new Vector2(0.5f, 0), new Vector2(0, 0.5f), new Vector2(0.5f, 1), new Vector2(1, 0.5f),
    };

    public List<Vector2> GetFenceConnects()
    {
        List<Vector2> deleteList = new List<Vector2>();
        Dictionary<Vector2, int> map = new Dictionary<Vector2, int>();
        foreach (var fence in Fences)
        {
            foreach (var line in lines)
            {
                var pos = fence + line;
                if (map.ContainsKey(pos))
                {
                    map[pos]++;
                    if (map[pos] >= 2)
                    {
                        deleteList.Add(pos);
                    }
                }
                else
                {
                    map.Add(pos, 1);
                }
            }
        }
        foreach (var key in deleteList)
        {
            map.Remove(key);
        }
        return map.Keys.ToList();
    }

    public void AddAnimal(int animalId, int count)
    {
        int index = -1;
        for (int i = 0; i < AnimalCounts.Count; i++)
        {
            var info = AnimalCounts[i];
            if (info.x == animalId)
            {
                var newCount = info.y + count;
                AnimalCounts.Remove(info);
                AnimalCounts.Add(new Vector2Int(animalId, newCount));
                index = i;
                break;
            }
        }
        if (index < 0)
        {
            AnimalCounts.Add(new Vector2Int(animalId, count));
        }
    }

    public void RemoveAnimal(int animalId, int count)
    {
        for (int i = 0; i < AnimalCounts.Count; i++)
        {
            var info = AnimalCounts[i];
            if (info.x == animalId)
            {
                var newCount = info.y - count;
                AnimalCounts.Remove(info);
                if (newCount > 0)
                {
                    AnimalCounts.Add(new Vector2Int(animalId, newCount));
                }
                break;
            }
        }
    }
}
