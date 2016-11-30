using System.Collections.Generic;

namespace EnerBank.Interfaces
{
	public interface IWorkSessionRepository
	{
		
		List<IWorkSession> GetAll();

		bool TryGetById(string id, out IWorkSession item);

		IWorkSession InsertNew(IWorkSession workSession);

		//IWorkSession InsertNew(string fileContentAccrediti, string fileContentEstrazioni);

		IWorkSession DeleteById(string id);

		void ClearRepo();

	}
}
