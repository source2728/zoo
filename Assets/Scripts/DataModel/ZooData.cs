using System;

[Serializable]
public class ZooData
{
    public string Name;
    public int Popular;
    public int VisitorLike;
    public int Price;

    public int AnimalCount;
    public int AnimalHappiness;

    public int VisitorCount;
    public int ExpectIncome;

    public void Fill(ZooData data)
    {
        Name = data.Name;
        Popular = data.Popular;
        VisitorLike = data.VisitorLike;
        Price = data.Price;
        VisitorCount = data.VisitorCount;
        ExpectIncome = data.ExpectIncome;
        AnimalCount = data.AnimalCount;
        AnimalHappiness = data.AnimalHappiness;
    }
}
