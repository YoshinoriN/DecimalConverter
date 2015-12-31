using System.Windows.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DecimalConverter.ViewModels
{
    public class ViewModelBase : DispatcherObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
