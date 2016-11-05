using System;

namespace EnerBank.Interfaces
{
	public interface IAccredito
	{

		string Descrizione { get; set; }
		decimal Importo { get; set; }
		DateTime Orario { get; set; }
		int NumeroTransazioni { get; set; }
		
	}
}
