using System;
using EnerBank.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enerbank.Model.Test
{
	[TestClass]
	public class AccreditiTest
	{

		string[] csvAccrediti = (string[]) DataUtils.AccreditiMocked.Clone();

		Accrediti accrediti;

		[TestInitialize]
		public void Initialize() {
			accrediti = new Accrediti();

		}

		[TestMethod]
		public void TestMethod1() {

		}

		[TestCleanup]
		public void Cleanup() {

		}

	}
}
