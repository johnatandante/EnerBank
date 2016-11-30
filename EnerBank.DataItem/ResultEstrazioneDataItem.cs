
using System.Globalization;
using EnerBank.Interfaces;

namespace EnerBank.DataItem
{
	public class ResultEstrazioneDataItem : IResultEstrazione
	{
		static NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

		public decimal ImportoTotale { get; set; }
		public int TransazioniTotale { get; set; }

		#region IExportable Members

		public override string ToString() {
			return string.Join(",", ImportoTotale.ToString("0.00", nfi), TransazioniTotale.ToString());
		}

		#endregion
	}
}
