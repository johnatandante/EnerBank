
namespace EnerBank.Interfaces
{
	public interface IWorkSession
	{
		string Id { get; set; }

		IAccrediti Source { get; }

		IEstrazioni Filtro { get; }

		string ResultFileName { get; set; }
	}
}
