using System;
using System.Windows.Input;

namespace CommandLineInterface
{
    /// <summary>
    ///     This class implements ICommand interface.
    /// </summary>
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
        
        /// <summary>
        ///     Says wether it's posible to execute command.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter = null)
        {
            if (_canExecuteCommandName == null)
            {
                return true;
            }

            return _canExecuteCommandName.Invoke();
        }

        /// <summary>
        ///     Executes command with it parameters.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter = null)
        {
            _executeCommandName?.Invoke();
        }
    }
}
