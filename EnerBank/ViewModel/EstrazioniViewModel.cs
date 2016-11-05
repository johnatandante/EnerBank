using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using EnerBank.DataItem;
using EnerBank.Interfaces;
using EnerBank.Model;
using EnerBank.UI.MVVMLight;

namespace EnerBank.ViewModel
{
	public class EstrazioniViewModel : MVVMLightContext
	{

		List<IResultEstrazione> _Estrazioni = new List<IResultEstrazione>();
		public ICollectionView Estrazioni { get; set; }

		public ICommand CaricaAccreditiCommand { get; set; }

		public ICommand CaricaEstrazioniCommand { get; set; }

		public ICommand EvaluateEstrazioniCommand { get; set; }

		bool _AccreditiLoaded;
		public bool AccreditiLoaded { get { return _AccreditiLoaded; } set { Notify<bool>(value, "AccreditiLoaded", out _AccreditiLoaded); } }

		bool _EstrazioniLoaded;
		public bool EstrazioniLoaded { get { return _EstrazioniLoaded; } set { Notify<bool>(value, "EstrazioniLoaded", out _EstrazioniLoaded); } }

		IAccrediti accrediti;

		IEstrazioni estrazioni;

		public EstrazioniViewModel() {

			CaricaAccreditiCommand = new RelayCommand(() => {
				CaricaAccrediti();
			});

			CaricaEstrazioniCommand = new RelayCommand(() => {
				CaricaEstrazioni();
			});

			EvaluateEstrazioniCommand = new RelayCommand(() => {
				EvaluateEstrazioni();
			});

			_Estrazioni.Add(new CustomResult() { ImportoTotale = 100, TransazioniTotale = 3  });
			_Estrazioni.Add(new CustomResult() { ImportoTotale = 1100, TransazioniTotale = 23 });
			_Estrazioni.Add(new CustomResult() { ImportoTotale = 223, TransazioniTotale = 13 });
			Estrazioni = new ListCollectionView(_Estrazioni);

			Estrazioni.Refresh();
		}

		private void EvaluateEstrazioni() {
			_Estrazioni.Clear();
			IReportEstrazioneAccrediti result = accrediti.Report(estrazioni);

			foreach(IResultEstrazione estrazione in result.Items)
				_Estrazioni.Add(new CustomResult() { ImportoTotale = estrazione.ImportoTotale, TransazioniTotale = estrazione.TransazioniTotale });
			Estrazioni.Refresh();
		}

		private void CaricaAccrediti() {
			accrediti = new Accrediti();

			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				accrediti.Read(dialog.FileName);

				AccreditiLoaded = accrediti.Items.Any();
			}
			
		}

		private void CaricaEstrazioni() {
			estrazioni = new Estrazioni();

			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				estrazioni.Read(dialog.FileName);

				EstrazioniLoaded = estrazioni.Items.Any();
			}
		}


	}
}
