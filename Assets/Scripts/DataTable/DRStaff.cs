using GameFramework.DataTable;
using System.Collections.Generic;
namespace DataTable
{
	public class DRStaff : IDataRow
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

		public int RecruitCost
		{
			get;
			protected set;
		}

		public int FireCost
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
			RecruitCost = int.Parse(text[index++]);
			FireCost = int.Parse(text[index++]);
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DRStaff > ();
		}
	}
}
