using GameFramework.DataTable;
using System.Collections.Generic;
namespace DataTable
{
	public class DRFence : IDataRow
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

		public int BuildCost
		{
			get;
			protected set;
		}

		public int DamageReturn
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

		public string StakeModelPath
		{
			get;
			protected set;
		}

		public string WoodModelPath
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
			BuildCost = int.Parse(text[index++]);
			DamageReturn = int.Parse(text[index++]);
			Width = int.Parse(text[index++]);
			Height = int.Parse(text[index++]);
			StakeModelPath = text[index++];
			WoodModelPath = text[index++];
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DRFence > ();
		}
	}
}
