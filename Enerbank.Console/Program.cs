using System.IO;
using EnerBank.Interfaces;
using EnerBank.Model.Services;

namespace EnerBank.Console
{
	class Program
	{
		//static string DefaultOutputFile = "output.csv";

		static void Main(string[] args) {
			
			//Il primo file CSV conterrà il dataset con le informazioni relative ad una serie di accrediti, 
			//Il file CSV del dataset avrà N righe, puoi supporre N < 1000.

			if (args.Length > 0)
				System.Console.WriteLine("File accrediti: " + args[0]);
			
			//Il secondo file CSV avrà un unico campo:
			//Il file CSV con le estrazioni avrà M righe, puoi supporre M < 100.
			if (args.Length > 1)
				System.Console.WriteLine("File elaborazioni: " + args[1]);

			if (args.Length < 2) {
				System.Console.WriteLine("Previsti due file in input come parametri, forniti: " + args.Length);
				return;
			}
			
			// Il software dovrà aiutare l'utente a processare una serie di dati derivanti da alcune
			// transazioni bancarie; in particolare, sarà necessario leggere alcuni file contenenti 
			// i riepiloghi giornalieri dei bonifici effettuati in alcune banche, e creare alcuni dati 
			// a partire da questi.

			ModelFactory environment = SessionWorker.GetNewEnvironment();

			IWorkSession result = environment
										.GetNew<ISessionWorker>(environment)
										.Run(args[0], args[1])
										.GetResult();
			
			FileInfo fileInfo = new FileInfo(result.ResultFileName);

			System.Console.WriteLine("File disponibile: " + fileInfo.FullName);

		}
	}
}
