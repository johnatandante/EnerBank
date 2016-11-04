using System;
using EnerBank.Interfaces;

namespace EnerBank.DataItem
{
	public class FiltroEstrazioniDataItem : IFiltroEstrazione
	{
		public DateTime Orario { get; set; }
	}
}
