using System;
using System.Collections.Generic;
using EnerBank.DataItem;
using EnerBank.Interfaces;
using EnerBank.IOUtils;

namespace EnerBank.Model
{
	public class FiltroEstrazioni
	{
		List<IFiltroEstrazione> Items = new List<IFiltroEstrazione>();

		public List<IFiltroEstrazione> GetAll() {
			return Items;
		}

		public void Read(string fileName) {

			foreach (string item in Reader.Read(fileName)) {
				IFiltroEstrazione filtro =  Parse(item);

				// Skip if null
				if (filtro == null)
					continue;

				Items.Add(filtro);

			}

		}

		/// <summary>
		/// Il record ha i seguenti campi
		/// data/orario da estrarre, stesso formato di cui sopra, sempre con precisione secondi e timezone offset sempre presente
		/// </summary>
		private static IFiltroEstrazione Parse(string record) {

			IFiltroEstrazione filtro = FiltroEstrazioni.GetNewItem();
			string[] fields =  Reader.Tokenize(record);
			if (fields.Length > 1)
				throw new Exception("Struttura del file non compatibile con la struttura richiesta di 1 campo: " + record);

			int i = 0;
			DateTime dateValue;
			if (DateTime.TryParse(fields[i++], out dateValue))
				filtro.Orario = dateValue;

			return filtro;
		}

		internal static IFiltroEstrazione GetNewItem() {
			return Activator.CreateInstance<FiltroEstrazioniDataItem>();
		}
	}
}
