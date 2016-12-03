using System;
using EnerBank.Interfaces;
using EnerBank.Model;
using EnerBank.Model.Services;
using Xunit;

namespace Enerbank.Model.Test
{

	public class EstrazioniTest
	{
		string[] csvEstrazioni = (string[])DataUtils.FiltroEstrazioniMocked.Clone();

		IEstrazioni estrazioni;
		ModelFactory environment = null;

		public EstrazioniTest() {
			environment = ModelFactory.Instance
							.Map<IEstrazioni, Estrazioni>();	

			estrazioni = environment.GetNew<IEstrazioni>();
			
		}

		[Fact]
		public void TestMethod1() {

		}

		~EstrazioniTest() {

		}
	}
}
