using GameFramework.DataTable;
using System.Collections.Generic;
namespace DataTable
{
	public class DREvent : IDataRow
	{
		public int Id
		{
			get;
			protected set;
		}

		public string Content
		{
			get;
			protected set;
		}

		public string SuccessContent
		{
			get;
			protected set;
		}

		public string FailContent
		{
			get;
			protected set;
		}

		public int SuccessRate
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
			Content = text[index++];
			SuccessContent = text[index++];
			FailContent = text[index++];
			SuccessRate = int.Parse(text[index++]);
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREvent > ();
		}
	}
}
