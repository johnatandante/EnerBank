using System;
using System.Collections.Generic;
using System.Linq;
using EnerBank.DataItem;
using EnerBank.Interfaces;
using EnerBank.IOUtils;

namespace EnerBank.Model
{
	public class Accrediti
	{

		List<IAccredito> Items = new List<IAccredito>();

		public void Read(string fileName) {			
			
			foreach (string item in Reader.Read(fileName)) {
				IAccredito accredito =  Parse(item);

				// Skip if null
				if (accredito == null)
					continue;

				Items.Add(accredito);

			}

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
			if (fields.Length > 4)
				throw new Exception("Struttura del file non compatibile con la struttura richiesta di 4 campi: " + record);

			int i = 0;
			accredito.Descrizione = fields[i++];
			
			decimal value;
			if (decimal.TryParse(fields[i++], out value))
				accredito.Importo = value;

			DateTime dateValue;
			if (DateTime.TryParse(fields[i++], out dateValue))
				accredito.Orario = dateValue;

			uint uintValue;
			if(uint.TryParse(fields[i++], out uintValue))
				accredito.NumeroTransazioni = uintValue;

			return accredito;
		
		}
		

		/// <summary>
		/// Per ciascuna riga presente nel secondo file CSV sarà necessario recuperare dal dataset l'accredito avvenuto in 
		/// quell'esatto istante o, qualora tale accredito manchi nel dataset, il primo accredito immediatamente 
		/// successivo; 
		/// </summary>
		public ReportEstrazioneAccrediti Report(FiltroEstrazioni filtroEstrazioni) {
			ReportEstrazioneAccrediti report = new ReportEstrazioneAccrediti();
			foreach (IFiltroEstrazione filtro in filtroEstrazioni.GetAll()) {
				report.Evaluate(GetByFiltro(filtro));

			}

			return report;
		}

		private List<IAccredito> GetByFiltro(IFiltroEstrazione filtro) {
			List<IAccredito> list = new List<IAccredito>();			
			list.AddRange(MatchItemsByTime(GetNearestOrarioFrom(filtro.Orario)));

			return list;

		}

		private DateTime GetNearestOrarioFrom(DateTime dateTime) {			
			IAccredito firstAccredito = Items.FirstOrDefault( i => i.Orario >= dateTime);
			return firstAccredito == null ? DateTime.MaxValue : firstAccredito.Orario;
		}

		private IEnumerable<IAccredito> MatchItemsByTime(DateTime dateTime) {
			return Items.Where(i => i.Orario == dateTime);
		}

		internal static IAccredito GetNewItem() {
			return Activator.CreateInstance<AccreditoDataItem>();
		}

	}
}
