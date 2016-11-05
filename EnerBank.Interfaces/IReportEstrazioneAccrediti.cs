using System.Collections.Generic;

namespace EnerBank.Interfaces
{
	public interface IReportEstrazioneAccrediti
	{
		List<IResultEstrazione> Items { get; }

		void Evaluate(List<IAccredito> list);

		string Export(string fileName);
	}
}
