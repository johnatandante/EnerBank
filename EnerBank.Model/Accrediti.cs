using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EnerBank.DataItem;
using EnerBank.Interfaces;
using EnerBank.IOUtils;

namespace EnerBank.Model
{
	public class Accrediti : IAccrediti
	{

		readonly List<IAccredito> _Items = new List<IAccredito>();

		public List<IAccredito> Items
		{
			get { return _Items; }
		}

		public void Read(string fileName) {
			Items.Clear();
			List<IAccredito> list = new List<IAccredito>();
			foreach (string item in Reader.Read(fileName)) {
				IAccredito accredito =  Parse(item);
				
				// Skip if null
				if (accredito == null)
					continue;

				list.Add(accredito);

			}
			Items.AddRange( list.OrderBy(a => a.Orario));

		}

		/// <summary>
		/// Il record avrà i seguenti campi:
		/// descrizione dell'accredito, campo testuale libero
		/// importo dell'accredito in EUR, numero decimale che utilizza il punto come separatore decimale e ha sempre due cifre decimali
		/// data/orario di invio dell'accredito, formato ISO8601 con precisione secondi e timezone offset sempre presente, ovvero YYYY-MM-DDThh
		/// :mm:ssTZD (esempio: 2015-11-05T08:15:30+01:00 per indicare il 5 Novembre 2015, ora italiana 8.15 e trenta secondi)
		/// numero di transazioni accorpate in tale importo, numero intero
		/// </summary>
		private static IAccredito Parse(string record) {
			IAccredito accredito = Accrediti.GetNewItem();
			string[] fields =  Reader.Tokenize(record);
			if (fields.Length != 4)
				throw new Exception("Struttura del file non compatibile con la struttura richiesta di 4 campi: " + record);

			int i = 0;
			accredito.Descrizione = fields[i++];
			
			decimal value;
			if (decimal.TryParse(fields[i++], NumberStyles.Any, CultureInfo.InvariantCulture, out value))
				accredito.Importo = value;

			DateTime dateValue;
			if (DateTime.TryParse(fields[i++], out dateValue))
				accredito.Orario = dateValue;

			int uintValue;
			if(int.TryParse(fields[i++], out uintValue))
				accredito.NumeroTransazioni = uintValue;

			return accredito;
		
		}
		
		/// <summary>
		/// Per ciascuna riga presente nel secondo file CSV sarà necessario recuperare dal dataset l'accredito avvenuto in 
		/// quell'esatto istante o, qualora tale accredito manchi nel dataset, il primo accredito immediatamente 
		/// successivo; 
		/// </summary>
		public IReportEstrazioneAccrediti Report(IEstrazioni filtroEstrazioni) {
			ReportEstrazioneAccrediti report = new ReportEstrazioneAccrediti();
			foreach (IEstrazione filtro in filtroEstrazioni.Items) {
				report.Evaluate(GetByFiltro(filtro));

			}

			return report;
		}

		private List<IAccredito> GetByFiltro(IEstrazione filtro) {
			List<IAccredito> list = new List<IAccredito>();			
			list.AddRange(MatchItemsByTime(GetNearestOrarioFrom(filtro.Orario)));

			return list;
		}

		private DateTime GetNearestOrarioFrom(DateTime orario) {			
			IAccredito firstAccredito = Items.FirstOrDefault( i => i.Orario >= orario);
			return firstAccredito == null ? DateTime.MaxValue : firstAccredito.Orario;
		}

		private IEnumerable<IAccredito> MatchItemsByTime(DateTime orario) {
			return Items.Where(i => i.Orario == orario);
		}

		internal static IAccredito GetNewItem() {
			return Activator.CreateInstance<AccreditoDataItem>();
		}

	}
}
