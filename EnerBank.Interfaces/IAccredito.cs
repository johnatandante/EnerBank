using System;

namespace EnerBank.Interfaces
{
	public interface IAccredito
	{

		string Descrizione { get; set; }
		decimal Importo { get; set; }
		DateTime Orario { get; set; }
		ulong NumeroTransazioni { get; set; }
		
	}
}
