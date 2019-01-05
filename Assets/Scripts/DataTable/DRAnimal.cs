using GameFramework.DataTable;
using System.Collections.Generic;
namespace DataTable
{
	public class DRAnimal : IDataRow
	{
		public int Id
		{
			get;
			protected set;
		}

		public string Name
		{
			get;
			protected set;
		}

		public int Type
		{
			get;
			protected set;
		}

		public int GroupSize
		{
			get;
			protected set;
		}

		public int FitType
		{
			get;
			protected set;
		}

		public int BuyCost
		{
			get;
			protected set;
		}

		public int SellReturn
		{
			get;
			protected set;
		}

		public float FactorQ
		{
			get;
			protected set;
		}

		public int Width
		{
			get;
			protected set;
		}

		public int Height
		{
			get;
			protected set;
		}

		public string ModelPath
		{
			get;
			protected set;
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = dataRowText.Split('\t');
			int index = 0;
			index++;
			Id = int.Parse(text[index++]);
			index++;
			Name = text[index++];
			Type = int.Parse(text[index++]);
			GroupSize = int.Parse(text[index++]);
			FitType = int.Parse(text[index++]);
			BuyCost = int.Parse(text[index++]);
			SellReturn = int.Parse(text[index++]);
			FactorQ = float.Parse(text[index++]);
			Width = int.Parse(text[index++]);
			Height = int.Parse(text[index++]);
			ModelPath = text[index++];
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DRAnimal > ();
		}
	}
}
