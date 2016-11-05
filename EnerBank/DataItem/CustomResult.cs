using EnerBank.Interfaces;

namespace EnerBank.DataItem
{
	internal class CustomResult : IResultEstrazione
	{
		public decimal ImportoTotale { get; set; }

		public int TransazioniTotale { get; set; }

		public override string ToString() {
			return "Totale importi: " + ImportoTotale + " - Transazioni: " + TransazioniTotale;
		}
	}
}
