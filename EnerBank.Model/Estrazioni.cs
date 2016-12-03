using System;
using System.Collections.Generic;
using EnerBank.Interfaces;
using EnerBank.IOUtils;
using EnerBank.Model.Services;

namespace EnerBank.Model
{
	public class Estrazioni : IEstrazioni
	{
		readonly List<IEstrazione> _Items = new List<IEstrazione>();

		public List<IEstrazione> Items {
			get
			{
				return _Items;
			}
		}

		readonly ModelFactory Factory = null;

		public Estrazioni(ModelFactory factory){
			Factory = factory ?? ModelFactory.Instance;

		}

		public void Read(string fileName) {
			Items.Clear(); 
			foreach (string item in Reader.Read(fileName)) {
				IEstrazione filtro =  Parse(item);

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
		private IEstrazione Parse(string record) {

			IEstrazione filtro = Factory.GetNew<IEstrazione>();
			string[] fields =  Reader.Tokenize(record);
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
