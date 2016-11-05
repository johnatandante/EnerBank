using System;
using EnerBank.Interfaces;

namespace EnerBank.DataItem
{
	public class EstrazioneDataItem : IEstrazione
	{
		public DateTime Orario { get; set; }
	}
}
