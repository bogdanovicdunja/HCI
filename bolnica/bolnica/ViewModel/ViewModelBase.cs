using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.ViewModel
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prpertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prpertyName));
        }
    }
}
