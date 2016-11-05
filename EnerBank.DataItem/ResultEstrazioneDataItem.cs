
using EnerBank.Interfaces;

namespace EnerBank.DataItem
{
	public class ResultEstrazioneDataItem : IResultEstrazione
	{
		public decimal ImportoTotale { get; set; }
		public int TransazioniTotale { get; set; }

		#region IExportable Members

		public override string ToString() {
			return string.Join(",", ImportoTotale.ToString(), TransazioniTotale.ToString());
		}

		#endregion
	}
}
