using System;
using System.Windows.Input;

namespace CommandLineInterface
{
    /// <summary>
    ///     This class implements ICommand interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        /// <summary>
        ///     Says wether it's posible to execute command.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecuteCommandName == null)
            {
                return true;
            }

            return _canExecuteCommandName.Invoke((T)parameter);
        }

        /// <summary>
        ///     Executes command with it parameters.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _executeCommandName?.Invoke((T)parameter);
        }
    }
}
