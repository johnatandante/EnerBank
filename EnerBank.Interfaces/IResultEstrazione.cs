using System;

namespace EnerBank.Interfaces
{
	public interface IResultEstrazione
	{
		DateTime Data { get; set; }
		decimal ImportoTotale { get; set; }
		int TransazioniTotale { get; set; }

	}
}
