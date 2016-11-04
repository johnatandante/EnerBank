using System;
using EnerBank.Interfaces;

namespace EnerBank.DataItem
{
	public class AccreditoDataItem : IAccredito
	{

		public string Descrizione { get; set; }
		public decimal Importo { get; set; }
		public DateTime Orario { get; set; }
		public ulong NumeroTransazioni { get; set; }
		
	}
}
