using System.Collections.Generic;

namespace EnerBank.Interfaces
{
	public interface IEstrazioni
	{
		List<IEstrazione> Items { get; }

		void Read(string fileName);
	}
}
