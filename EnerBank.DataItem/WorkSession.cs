﻿
using EnerBank.Interfaces;

namespace EnerBank.DataItem
{
	public class WorkSession : IWorkSession
	{
		#region IWorkSession Members

		public string Id { get; set; }

		public IAccrediti Source { get; private set; }

		public IEstrazioni Filtro { get; private set; }

		public string ResultFileName { get; set; }

		#endregion

		public WorkSession(IAccrediti source, IEstrazioni filtro) {
			this.Source = source;
			this.Filtro = filtro;

			ResultFileName = string.Empty;
		}

	}
}
