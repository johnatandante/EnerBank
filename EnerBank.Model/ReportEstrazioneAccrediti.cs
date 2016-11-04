﻿using System;
using System.Collections.Generic;
using System.Linq;
using EnerBank.DataItem;
using EnerBank.Interfaces;

namespace EnerBank.Model
{
	public class ReportEstrazioneAccrediti
	{

		List<IResultEstrazione> Items = new List<IResultEstrazione>();

		internal static IResultEstrazione GetNewItem() {
			return Activator.CreateInstance<ResultDataItem>();
		}

		/// <summary>
		/// Una volta identificati questi M accrediti, sarà necessario calcolare:
		/// a) l'importo totale degli accrediti così identificati
		/// b) la somma totale del numero di transazioni accorpate negli accrediti così identificati.
		/// </summary>
		internal void Evaluate(List<IAccredito> list) {
			IResultEstrazione item = Activator.CreateInstance<ResultDataItem>();
			item.ImportoTotale = list.Sum( i => i.Importo);
			item.TransazioniTotale = (ulong)list.Sum(i => (decimal)i.NumeroTransazioni);
		}
	}
}
