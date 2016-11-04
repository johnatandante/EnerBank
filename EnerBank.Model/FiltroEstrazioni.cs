using System;
using System.Collections.Generic;
using EnerBank.DataItem;
using EnerBank.Interfaces;

namespace EnerBank.Model
{
	public class FiltroEstrazioni
	{
		List<IFiltroEstrazione> Items = new List<IFiltroEstrazione>();

		public List<IFiltroEstrazione> GetAll() {
			return Items;
		}

		public void Read(string fileName) {

			foreach (string item in Reader.Read(fileName)) {
				IFiltroEstrazione filtro =  Reader.ToFiltroEstrazione(item);

				// Skip if null
				if (filtro == null)
					continue;

				Items.Add(filtro);

			}

		}

		internal static IFiltroEstrazione GetNewItem() {
			return Activator.CreateInstance<FiltroEstrazioniDataItem>();
		}
	}
}
