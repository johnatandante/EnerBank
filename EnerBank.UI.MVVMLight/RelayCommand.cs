using System;
using System.Windows.Input;

namespace EnerBank.UI.MVVMLight
{
	public class RelayCommand : ICommand
	{
#pragma warning disable 67
		public event EventHandler CanExecuteChanged;
#pragma warning restore 67

		Action _Action;

		public RelayCommand(Action action) {
			_Action = action;
		}

		public bool CanExecute(object parameter) {
			return _Action != null;
		}

		public void Execute(object parameter) {
			_Action?.Invoke();
		}
	}
}
