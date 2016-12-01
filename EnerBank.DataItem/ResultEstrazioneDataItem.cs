
using System;
using System.Globalization;
using EnerBank.Interfaces;

namespace EnerBank.DataItem
{
	public class ResultEstrazioneDataItem : IResultEstrazione
	{
		static NumberFormatInfo nfi = new CultureInfo("en-US").NumberFormat;

		public DateTime Data { get; set; }

		public decimal ImportoTotale { get; set; }
		public int TransazioniTotale { get; set; }

		#region IExportable Members

		public override string ToString() {
			return string.Join(",", Data.ToString("yyyy-MM-dd-hh:mm:ss"), ImportoTotale.ToString("0.00", nfi), TransazioniTotale.ToString());
		}

		#endregion
	}
}
