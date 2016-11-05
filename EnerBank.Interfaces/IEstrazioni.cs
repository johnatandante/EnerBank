using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnerBank.Interfaces
{
	public interface IEstrazioni
	{
		List<IEstrazione> Items { get; }

		void Read(string fileName);
	}
}
