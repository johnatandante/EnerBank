using System;
using System.IO;
using EnerBank.Interfaces;
using EnerBank.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enerbank.Model.Test
{
	[TestClass]
	public class AccreditiTest
	{

		string[] csvAccrediti = (string[]) DataUtils.AccreditiMocked.Clone();
		string[] csvEstrazioni = (string[]) DataUtils.FiltroEstrazioniMocked.Clone();

		static string csvAccreditiFileName  = string.Empty;
		static string csvEstrazioniFileName = string.Empty;

		IAccrediti accrediti;
		IEstrazioni filtro;

		[TestInitialize]
		public void Initialize() {
			accrediti = new Accrediti();
			csvAccreditiFileName = Path.GetTempFileName();
			File.WriteAllText(csvAccreditiFileName, string.Join(Environment.NewLine, csvAccrediti));

			filtro = new Estrazioni();
			csvEstrazioniFileName = Path.GetTempFileName();
			File.WriteAllText(csvEstrazioniFileName, string.Join(Environment.NewLine, csvEstrazioni));
			filtro.Read(csvEstrazioniFileName);
		}

		[TestMethod]
		public void FromACsvFileName_ReadFileMustFillItemCollection() {
			accrediti.Read(csvAccreditiFileName);
			Assert.IsTrue(accrediti.Items.Count > 0);

		}

		[TestMethod]
		public void FromAFiltroEstrazione_ResultMustBeNonEmpty() {
			accrediti.Read(csvAccreditiFileName);
			IReportEstrazioneAccrediti result = accrediti.Report(filtro);
			Assert.IsTrue(result.Items.Count > 0);
		}

		[TestCleanup]
		public void Cleanup() {
			File.Delete(csvAccreditiFileName);
			File.Delete(csvEstrazioniFileName);

		}

	}
}
