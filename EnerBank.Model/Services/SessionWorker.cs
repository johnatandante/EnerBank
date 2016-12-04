using EnerBank.DataItem;
using EnerBank.Interfaces;
using Environment.Injector;

namespace EnerBank.Model.Services
{
	public class SessionWorker : ISessionWorker
	{

		public string OutputFile { get; set; }

		IWorkSession session = null;
		
		readonly ModelService Factory = null;

		public SessionWorker(ModelService environment) {
			Factory = environment ?? ModelService.Instance;
			
		}

		public ISessionWorker Run(string sourceFileName, string filterFileName){
			IAccrediti accrediti = Factory.GetNew<IAccrediti>(Factory);
			IEstrazioni estrazioni = Factory.GetNew<IEstrazioni>(Factory);

			session = Factory.GetNew<IWorkSession>(accrediti, estrazioni);

			session.Source.Read(sourceFileName);

			session.Filtro.Read(filterFileName);
			
			session.ResultFileName = session.Source.Report(session.Filtro).ExportToFile(OutputFile);

			return this;
		}

		public IWorkSession GetResult() {
			return session;
		}

		public static ModelService GetNewEnvironment() {
			ModelService environment = new ModelService();
			environment.Map<IAccredito, AccreditoDataItem>()
				.Map<IEstrazione, EstrazioneDataItem>()
				.Map<IResultEstrazione, ResultEstrazioneDataItem>()
				.Map<IReportEstrazioneAccrediti, ReportEstrazioneAccrediti>()
				.Map<IAccrediti, Accrediti>()
				.Map<IEstrazioni, Estrazioni>()
				.Map<IWorkSession, WorkSession>()
				.Map<ISessionWorker, SessionWorker>();

			return environment;

		}

	}
}
