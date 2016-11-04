using System.Linq;
using EnerBank.Model;

namespace Enerbank.Console
{
	class Program
	{
		static void Main(string[] args) {

			if (args.Length > 0)
				System.Console.WriteLine("File accrediti: " + args[0]);
			if (args.Length > 1)
				System.Console.WriteLine("File elaborazioni: " + args[1]);

			if (args.Length < 2) {
				System.Console.WriteLine("Previsti due file in input come parametri, forniti: " + args.Length);
				
			}
			
			// Il software che creerai dovrà aiutare l'utente a processare una serie di dati derivanti da alcune 			
			// transazioni bancarie; in particolare, sarà
			//necessario leggere alcuni file contenenti i riepiloghi giornalieri dei bonifici effettuati in alcune banche, 
			//e creare alcuni dati a partire da questi.

			//Il primo file CSV conterrà il dataset con le informazioni relative ad una serie di accrediti, 
			//Il file CSV del dataset avrà N righe, puoi supporre N < 1000.
			Accrediti accrediti = new Accrediti();
			accrediti.Read(args[0]);
						
			//Il secondo file CSV avrà un unico campo:
			FiltroEstrazioni filtroEstrazioni = new FiltroEstrazioni();
			//Il file CSV con le estrazioni avrà M righe, puoi supporre M < 100.
			filtroEstrazioni.Read(args[1]);
									
			ReportEstrazioneAccrediti report = accrediti.Report(filtroEstrazioni);
			string filename = report.Export();

			System.Console.WriteLine("File disponibile: " + filename);
			System.Diagnostics.Process.Start(filename);
		}
	}
}
