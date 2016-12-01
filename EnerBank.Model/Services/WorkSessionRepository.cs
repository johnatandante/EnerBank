using System;
using System.Collections.Generic;
using System.Linq;
using EnerBank.Interfaces;

namespace EnerBank.Model.Services
{
	public class WorkSessionRepository : IWorkSessionRepository
	{
		List<IWorkSession> _Repo = new List<IWorkSession>();

		static IWorkSessionRepository _StaticRepo = null;
		static IWorkSessionRepository StaticRepo {
			get {
				if (_StaticRepo == null)
					_StaticRepo = new WorkSessionRepository();

				return _StaticRepo;
			}
		}

		#region IWorkSessionRepository Members

		public List<IWorkSession> GetAll() {
			return _Repo.ToArray().ToList();
		}

		public bool TryGetById(string id, out IWorkSession item) {
			item = _Repo.FirstOrDefault( i => i.Id == id);
			return item != null;

		}

		public IWorkSession InsertNew(IWorkSession item) {
			item.Id = Guid.NewGuid().ToString();
			_Repo.Add(item);

			return item;
		}

		public IWorkSession DeleteById(string id) {
			IWorkSession item;			
			if (TryGetById(id, out item) && _Repo.Remove(item)) {
				return item;
			} else {
				return null;
			}
		}

		public void ClearRepo() {
			_Repo.Clear();

		}

		#endregion

		public static IWorkSessionRepository GetRepo() {
			return StaticRepo;
		}
	}
}
