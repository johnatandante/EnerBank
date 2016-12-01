using EnerBank.DataItem;
using EnerBank.Interfaces;

namespace EnerBank.Model.Services
{
	public class SessionWorker : ISessionWorker
	{

		IWorkSession session = null;
		
		SessionWorker(string sourceFileName, string filterFileName, string outputFile) {

			session = WorkSession.GetNew(new Accrediti(), new Estrazioni());

			session.Source.Read(sourceFileName);

			session.Filtro.Read(filterFileName);
			
			session.ResultFileName = session.Source.Report(session.Filtro).ExportToFile(outputFile);

		}

		public IWorkSession GetResult() {
			return session;
		}

		public static ISessionWorker GetNew(string sourceFileName, string filterFileName, string outputFile = null) {
			return new SessionWorker(sourceFileName, filterFileName, outputFile);

		}

	}
}
