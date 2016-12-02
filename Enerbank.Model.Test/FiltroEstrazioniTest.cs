using System;
using EnerBank.Model;
using Xunit;

namespace Enerbank.Model.Test
{

	public class FiltroEstrazioniTest
	{
		string[] csvEstrazioni = (string[])DataUtils.FiltroEstrazioniMocked.Clone();

		FiltroEstrazioni estrazioni;

		public FiltroEstrazioniTest() {
			estrazioni = new FiltroEstrazioni();

		}

		~FiltroEstrazioniTest() {

		}

		[Fact]
		public void TestName()
		{
		//Given
		
		//When
		
		//Then
		}
		
	}
}
