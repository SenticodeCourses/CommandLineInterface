using System;
using System.Windows.Input;

namespace CommandLineInterface
{
    public class Command<T> : ICommand
    {
        readonly Action<T> _executeCommandName;
        readonly Func<T, bool> _canExecuteCommandName;
        public event EventHandler CanExecuteChanged;

        public Command(Action<T> executeCommandName, Func<T, bool> canExecuteCommandName = null)
        {
            _executeCommandName = executeCommandName;
            _canExecuteCommandName = canExecuteCommandName;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteCommandName == null)
            {
                return true;
            }

            return _canExecuteCommandName.Invoke((T)parameter);
        }

        public void Execute(object parameter)
        {
            _executeCommandName?.Invoke((T)parameter);
        }
    }
}
