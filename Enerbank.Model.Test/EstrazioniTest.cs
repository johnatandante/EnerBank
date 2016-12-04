using System;
using System.IO;
using System.Linq;
using EnerBank.Interfaces;
using EnerBank.Model;
using Environment.Injector;
using Xunit;

namespace Enerbank.Model.Test
{

	public class EstrazioniTest
	{
		string[] csvEstrazioni = (string[])DataUtils.FiltroEstrazioniMocked.Clone();
		string[] csvEstrazioniEstrazioniSingleItem15_00 = 
			(string[]) DataUtils.FiltroEstrazioniSingleItem15_00Mocked.Clone();


		IEstrazioni estrazioni = null;
		ModelService environment = null;

		static string csvEstrazioniFileName = string.Empty;
		static string csvEstrazioniWithSingleOrarioFileName = string.Empty;

		public EstrazioniTest() {
			environment = DataUtils.GetNewDataEnvironment()
							.Map<IEstrazioni, Estrazioni>();

			estrazioni = environment.GetNew<IEstrazioni>(environment);
			
			csvEstrazioniFileName = Path.GetTempFileName();
			File.WriteAllText(csvEstrazioniFileName, string.Join(System.Environment.NewLine, csvEstrazioni));
			
			csvEstrazioniWithSingleOrarioFileName = Path.GetTempFileName();
			File.WriteAllText(csvEstrazioniWithSingleOrarioFileName, 
				string.Join(System.Environment.NewLine, csvEstrazioniEstrazioniSingleItem15_00));
			
		}

		~EstrazioniTest() {
			File.Delete(csvEstrazioniFileName);
			File.Delete(csvEstrazioniWithSingleOrarioFileName);
		}

		[Fact]
		public void FromAGiventCsvEstrazioniFileName_EstrazioniReadWillBeNonEmpty() {
			estrazioni.Read(csvEstrazioniFileName);
			Assert.True(estrazioni.Items.Count > 0);
		}

		[Fact]
		public void FromAGiventCsvEstrazioniWithSingleOrarioFileName_EstrazioniReadWillBeOneOnly() {
			estrazioni.Read(csvEstrazioniWithSingleOrarioFileName);
			Assert.True(estrazioni.Items.Count == 1);
		}

	}
}
