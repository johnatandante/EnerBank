using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnerBank.Interfaces;
using EnerBank.DataItem;

namespace EnerBank.Model
{
	public class Accrediti
	{

		List<IAccredito> Items = new List<IAccredito>();

		public void Read(string fileName) {			
			
			foreach (string item in Reader.Read(fileName)) {
				IAccredito accredito =  Reader.ToAccredito(item);

				// Skip if null
				if (accredito == null)
					continue;

				Items.Add(accredito);

			}

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
