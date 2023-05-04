using System;
using System.Windows.Input;

namespace MVVM
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action<object?>? _execute;
        private readonly Predicate<object?>? _canExecute;

        public bool CanExecute(object? parameter)
        {
            return (_canExecute == null) || _canExecute(parameter);
        }

        public void Execute(object? parameter = null)
        {
            if (_execute != null)
                _execute(parameter);
        }

        public RelayCommand(Action<object?>? execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public RelayCommand(Action execute, Predicate<object?>? canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = new Action<object?>((obj) => execute());
            _canExecute = canExecute;
        }
    }
}
