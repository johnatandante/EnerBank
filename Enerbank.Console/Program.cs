using System.Linq;
using EnerBank.Model;

namespace Enerbank.Console
{
	class Program
	{
		static void Main(string[] args) {

			// Il software che creerai dovrà aiutare l'utente a processare una serie di dati derivanti da alcune 			
			// transazioni bancarie; in particolare, sarà
			//necessario leggere alcuni file contenenti i riepiloghi giornalieri dei bonifici effettuati in alcune banche, 
			//e creare alcuni dati a partire da questi.

			//Il primo file CSV conterrà il dataset con le informazioni relative ad una serie di accrediti, 
			//Il file CSV del dataset avrà N righe, puoi supporre N < 1000.
			Accrediti accrediti = new Accrediti();
			accrediti.Read(args.First());
						
			//Il secondo file CSV avrà un unico campo:
			FiltroEstrazioni filtroEstrazioni = new FiltroEstrazioni();
			//Il file CSV con le estrazioni avrà M righe, puoi supporre M < 100.
			filtroEstrazioni.Read(args[1]);
									
			ReportEstrazioneAccrediti report = accrediti.Report(filtroEstrazioni);
			string filename = report.Export();

			System.Diagnostics.Process.Start(filename);
		}
	}
}
