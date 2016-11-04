using System;
using System.IO;
using System.Text.RegularExpressions;
using EnerBank.Interfaces;

namespace EnerBank.Model
{

    public class Reader
    {

		// string format = "YYYY-MM-DDThh:mm:ssTZD";

		/// <summary>
		/// Thanks to http://geekswithblogs.net/mwatson/archive/2004/09/04/10658.aspx
		/// </summary>
		static string regex = "(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)";

		public static string[] Read(string filename) {
			return File.ReadAllLines(filename);
		}

		/// <summary>
		/// Il record avrà i seguenti campi:
		/// descrizione dell'accredito, campo testuale libero
		/// importo dell'accredito in EUR, numero decimale che utilizza il punto come separatore decimale e ha sempre due cifre decimali
		/// data/orario di invio dell'accredito, formato ISO8601 con precisione secondi e timezone offset sempre presente, ovvero YYYY-MM-DDThh
		/// :mm:ssTZD (esempio: 2015-11-05T08:15:30+01:00 per indicare il 5 Novembre 2015, ora italiana 8.15 e trenta secondi)
		/// numero di transazioni accorpate in tale importo, numero intero
		/// </summary>
		internal static IAccredito ToAccredito(string record) {
			if (string.IsNullOrWhiteSpace(record))
				return null;

			IAccredito accredito = Accrediti.GetNewItem();
			string[] fields =  Regex.Split(record, regex);
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
		/// Il record ha i seguenti campi
		/// data/orario da estrarre, stesso formato di cui sopra, sempre con precisione secondi e timezone offset sempre presente
		/// </summary>
		/// <param name="record"></param>
		/// <returns></returns>
		internal static IFiltroEstrazione ToFiltroEstrazione(string record) {
			if (string.IsNullOrWhiteSpace(record))
				return null;

			IFiltroEstrazione filtro = FiltroEstrazioni.GetNewItem();
			string[] fields =  Regex.Split(record, regex);
			if (fields.Length > 1)
				throw new Exception("Struttura del file non compatibile con la struttura richiesta di 1 campo: " + record);

			int i = 0;
			DateTime dateValue;
			if (DateTime.TryParse(fields[i++], out dateValue))
				filtro.Orario = dateValue;

			return filtro;

		}

	}
	
}
