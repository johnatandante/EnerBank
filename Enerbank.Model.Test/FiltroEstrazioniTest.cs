using System;
using EnerBank.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enerbank.Model.Test
{
	[TestClass]
	public class FiltroEstrazioniTest
	{
		string[] csvEstrazioni = (string[])DataUtils.FiltroEstrazioniMocked.Clone();

		FiltroEstrazioni estrazioni;

		[TestInitialize]
		public void Initialize() {
			estrazioni = new FiltroEstrazioni();

		}

		[TestMethod]
		public void TestMethod1() {

		}

		[TestCleanup]
		public void Cleanup() {

		}
	}
}
