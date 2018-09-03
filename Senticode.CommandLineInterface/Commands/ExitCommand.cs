using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CommandLineInterface.Commands
{
    internal class ExitCommand<TSettings> : Command
        where TSettings : AppSettingsBase
    {
        public ExitCommand(TSettings settings) : this(async () =>
        {
            await settings.SaveAsync();
            Process.GetCurrentProcess().Kill();
        }, () => true)
        {

        }

        private ExitCommand(Action executeCommandName, Func<bool> canExecuteCommandName = null) :
            base(executeCommandName, canExecuteCommandName)
        {

        }
    }
}