
namespace EnerBank.Interfaces
{
	public interface IResultEstrazione
	{
		decimal ImportoTotale { get; set; }
		ulong TransazioniTotale { get; set; }

	}
}
