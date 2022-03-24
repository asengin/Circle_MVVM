using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Circle_MVVM
{
    class RelayCommand : ICommand
    {
        private readonly Action<object> excecute;
        private readonly Func<object, bool> canExcecute;
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute=null)
        {
            excecute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExcecute = CanExecute;
        }

        public bool CanExecute(object parameter) => canExcecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => excecute(parameter);
    }
}
