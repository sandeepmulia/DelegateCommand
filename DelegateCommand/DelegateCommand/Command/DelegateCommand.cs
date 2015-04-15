using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DelegateCommand
{
    public class RoutedCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RoutedCommand(Action<object> action)
        {
            _execute = action;
        }

        public RoutedCommand(Action<object> action, Predicate<object> predicate)
        {
            _execute = action;
            _canExecute = predicate;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute(parameter);
        }
    }
}
