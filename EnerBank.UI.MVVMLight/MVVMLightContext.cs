using System.ComponentModel;

namespace EnerBank.UI.MVVMLight
{

	public class MVVMLightContext : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChangedEvent(string propertyName) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void Notify<T>(T value, string propertyName, out T variable){
			variable = value;
			RaisePropertyChangedEvent(propertyName);

		}

	}
}
