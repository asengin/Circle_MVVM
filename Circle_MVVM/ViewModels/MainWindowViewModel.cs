using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Circle_MVVM.Models;

namespace Circle_MVVM.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double circumference;
        public double Circumference
        {
            get { return circumference; }
            set
            {
                circumference = value;
                OnPropertyChanged();
            }
        }

        public ICommand Result { get; }
        private void OnResultExecute(object p)
        {
            Circumference = Circle.Circumference(Radius);
        }
        private bool CanResultExecuted(object p)
        {
            if (Radius != 0)
                return true;
            else
                return false;
        }

        public MainWindowViewModel()
        {
            Result = new RelayCommand(OnResultExecute, CanResultExecuted);
        }
    }


}
