using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnerBank.DataItem;
using EnerBank.Interfaces;
using EnerBank.IOUtils;

namespace EnerBank.Model
{
	public class ReportEstrazioneAccrediti :IReportEstrazioneAccrediti
	{

		//public const string DefaultFileName = "result.csv";

		readonly List<IResultEstrazione> _Items = new List<IResultEstrazione>();

		public List<IResultEstrazione> Items
		{
			get { return _Items; }
		}

		internal static IResultEstrazione GetNewItem() {
			return Activator.CreateInstance<ResultEstrazioneDataItem>();
		}

		/// <summary>
		/// Una volta identificati questi M accrediti, sarà necessario calcolare:
		/// a) l'importo totale degli accrediti così identificati
		/// b) la somma totale del numero di transazioni accorpate negli accrediti così identificati.
		/// </summary>
		public void Evaluate(List<IAccredito> list) {
			IResultEstrazione item = Activator.CreateInstance<ResultEstrazioneDataItem>();
			item.ImportoTotale = list.Sum( i => i.Importo);
			item.TransazioniTotale = list.Sum(i => i.NumeroTransazioni);

			Items.Add(item);
		}

		public string ExportToFile(string fileName) {
			string fullFileName = fileName ?? Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
			return Writer.Write(Items.ToArray(), fullFileName);
		}
	}
}
