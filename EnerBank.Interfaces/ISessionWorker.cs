
namespace EnerBank.Interfaces
{
	public interface ISessionWorker
	{
		IWorkSession GetResult();

		ISessionWorker Run(string sourceFileName, string filterFileName);

	}
}
