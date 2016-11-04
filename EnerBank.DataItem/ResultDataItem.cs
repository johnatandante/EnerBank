
using EnerBank.Interfaces;

namespace EnerBank.DataItem
{
	public class ResultDataItem : IResultEstrazione
	{
		public decimal ImportoTotale { get; set; }
		public ulong TransazioniTotale { get; set; }

	}
}
