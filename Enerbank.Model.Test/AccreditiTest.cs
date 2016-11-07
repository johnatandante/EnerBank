using System;
using System.Linq;
using System.IO;
using EnerBank.Interfaces;
using EnerBank.Model;
using Xunit;

namespace Enerbank.Model.Test
{
	
	public class AccreditiTest
	{

		string[] csvAccrediti = (string[]) DataUtils.AccreditiMocked.Clone();
		string[] csvAccreditiWithImportoTotale100AndTrasazioniTotale10At15_00 = (string[]) DataUtils.AccreditiMockedWithImportoTotale100AndTrasazioniTotale10At15_00_Mocked.Clone();
		string[] csvEstrazioni = (string[]) DataUtils.FiltroEstrazioniMocked.Clone();
		string[] csvEstrazioniEstrazioniSingleItem15_00= (string[]) DataUtils.FiltroEstrazioniSingleItem15_00Mocked.Clone();

		IAccredito[] accreditiCollectionWithSingleOrarioOver12 = (IAccredito[] )DataUtils.AccreditiCollectionWithSingleOrarioOver12.Clone();
		IAccredito[] accreditiCollectionWithSingleOrario12 = (IAccredito[] )DataUtils.AccreditiCollectionWithSingleOrario12.Clone();
		IAccredito[] accreditiCollectionWithSingleOrarioBefore12= (IAccredito[] )DataUtils.AccreditiCollectionWithSingleOrarioBefore12.Clone();

		IEstrazione estrazioneWithOrario12 = DataUtils.EstrazioneWithOrario12;

		IResultEstrazione risultatoEstrazione15 = DataUtils.RisultatoEstrazioneItem15_00;

		static string csvAccreditiFileName  = string.Empty;
		static string csvAccreditiWith3RecordAt15_00_FileName  = string.Empty;
		static string csvEstrazioniFileName = string.Empty;
		static string csvEstrazioniWithWithSingleItemAt15_00_FileName  = string.Empty;

		IAccrediti accrediti;
		IEstrazioni filtro;
		IEstrazioni filtroWithSingleOrario12;
		IEstrazioni filtroWithSingleOrario15;

		public AccreditiTest() {
			accrediti = new Accrediti();
			csvAccreditiFileName = Path.GetTempFileName();
			File.WriteAllText(csvAccreditiFileName, string.Join(Environment.NewLine, csvAccrediti));

			filtro = new Estrazioni();
			csvEstrazioniFileName = Path.GetTempFileName();
			File.WriteAllText(csvEstrazioniFileName, string.Join(Environment.NewLine, csvEstrazioni));
			filtro.Read(csvEstrazioniFileName);

			filtroWithSingleOrario12 = new Estrazioni();
			filtroWithSingleOrario12.Items.Add(estrazioneWithOrario12);

			csvAccreditiWith3RecordAt15_00_FileName = Path.GetTempFileName();
			File.WriteAllText(csvAccreditiWith3RecordAt15_00_FileName, string.Join(Environment.NewLine, csvAccreditiWithImportoTotale100AndTrasazioniTotale10At15_00));

			filtroWithSingleOrario15 = new Estrazioni();
			csvEstrazioniWithWithSingleItemAt15_00_FileName = Path.GetTempFileName();
			File.WriteAllText(csvEstrazioniWithWithSingleItemAt15_00_FileName, string.Join(Environment.NewLine, csvEstrazioniEstrazioniSingleItem15_00));
			filtroWithSingleOrario15.Read(csvEstrazioniWithWithSingleItemAt15_00_FileName);
		}

//[Theory]
//[InlineData(-1)]
//[InlineData(0)]
//[InlineData(1)]
//public void ReturnFalseGivenValuesLessThan2(int value)
//{
//    var result = _primeService.IsPrime(value);
//
//    Assert.False(result, $"{value} should not be prime");
//}
		~AccreditiTest() {
			File.Delete(csvAccreditiFileName);
			File.Delete(csvEstrazioniFileName);
			File.Delete(csvAccreditiWith3RecordAt15_00_FileName);

		}

		[Fact]
		public void FromACsvFileName_ReadFileMustFillItemCollection() {
			accrediti.Read(csvAccreditiFileName);
			Assert.True(accrediti.Items.Count > 0);
		}

		[Fact]
		public void FromACsvFileNameAndASingleFiltroEstrazione1500_ResultMustMatchTo_1000_10() {
			accrediti.Read(csvAccreditiWith3RecordAt15_00_FileName);
			IReportEstrazioneAccrediti result = accrediti.Report(filtroWithSingleOrario15);
			Assert.True(result.Items.Count.Equals(filtroWithSingleOrario15.Items.Count));
			Assert.True(result.Items.Count.Equals(1));
			Assert.True(result.Items.Single().ImportoTotale.Equals(risultatoEstrazione15.ImportoTotale));
			Assert.True(result.Items.Single().TransazioniTotale.Equals(risultatoEstrazione15.TransazioniTotale));
		}


		[Fact]
		public void FromACsvFileNameAndAFiltroEstrazione_ResultMustBeNonEmpty() {
			accrediti.Read(csvAccreditiFileName);
			IReportEstrazioneAccrediti result = accrediti.Report(filtro);
			Assert.True(filtro.Items.Count.Equals(result.Items.Count));
			Assert.True(result.Items.Count > 0);
		}

		[Fact]
		public void FromAGivenAccreditiCollectionWithSingleOrarioBefore12AndACustomFilterWithOrario12_ResultMustBeEmpty() {
			accrediti.Items.AddRange(accreditiCollectionWithSingleOrarioBefore12);

			filtroWithSingleOrario12 = new Estrazioni();
			filtroWithSingleOrario12.Items.Add(estrazioneWithOrario12);

			IReportEstrazioneAccrediti result = accrediti.Report(filtroWithSingleOrario12);
			Assert.True(result.Items.Count.Equals(filtroWithSingleOrario12.Items.Count));
			Assert.True(result.Items.Count > 0);
			Assert.True(result.Items.Count == 1);
			Assert.True(result.Items.Single().ImportoTotale.Equals(0));
			Assert.True(result.Items.Single().TransazioniTotale.Equals(0));
		}

		[Fact]
		public void FromAGivenAccreditiCollectionWithSingleOrario12AndACustomFilterWithOrario12_ResultMustNotBeEmpty() {
			accrediti.Items.AddRange(accreditiCollectionWithSingleOrario12);

			IReportEstrazioneAccrediti result = accrediti.Report(filtroWithSingleOrario12);
			Assert.True(result.Items.Count.Equals(filtroWithSingleOrario12.Items.Count));
			Assert.True(result.Items.Count > 0);
			Assert.True(result.Items.Count == 1);
			Assert.True(result.Items.Single().ImportoTotale.Equals(accreditiCollectionWithSingleOrarioBefore12.Single().Importo));
			Assert.True(result.Items.Single().TransazioniTotale.Equals(accreditiCollectionWithSingleOrarioBefore12.Single().NumeroTransazioni));

		}

		[Fact]
		public void FromAGivenAccreditiCollectionWithSingleOrarioOver12AndACustomFilterWithOrario12_ResultMustBeNotEmpty() {
			accrediti.Items.AddRange(accreditiCollectionWithSingleOrarioOver12);

			IReportEstrazioneAccrediti result = accrediti.Report(filtroWithSingleOrario12);
			Assert.True(result.Items.Count.Equals(filtroWithSingleOrario12.Items.Count));
			Assert.True(result.Items.Count > 0);
			Assert.True(result.Items.Count == 1);
			Assert.True(result.Items.Single().ImportoTotale.Equals(accreditiCollectionWithSingleOrarioBefore12.Single().Importo));
			Assert.True(result.Items.Single().TransazioniTotale.Equals(accreditiCollectionWithSingleOrarioBefore12.Single().NumeroTransazioni));
		}

	}
}
