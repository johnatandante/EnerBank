using System.Collections.Generic;

namespace EnerBank.Interfaces
{
	public interface IAccrediti
	{
		List<IAccredito> Items { get; }

		void Read(string csvFileName);

		IReportEstrazioneAccrediti Report(IEstrazioni filtroEstrazioni);

	}
}
