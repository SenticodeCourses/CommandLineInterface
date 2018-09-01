using System;
using System.Windows.Input;

namespace CommandLineInterface
{
    public class Command : ICommand
    {
        readonly Action _executeCommandName;
        readonly Func<bool> _canExecuteCommandName;
        public event EventHandler CanExecuteChanged;

        public Command(Action executeCommandName, Func<bool> canExecuteCommandName = null)
        {
            _executeCommandName = executeCommandName;
            _canExecuteCommandName = canExecuteCommandName;
        }
        
        public bool CanExecute(object parameter = null)
        {
            if (_canExecuteCommandName == null)
            {
                return true;
            }

            return _canExecuteCommandName.Invoke();
        }

        public void Execute(object parameter = null)
        {
            _executeCommandName?.Invoke();
        }
    }
}
