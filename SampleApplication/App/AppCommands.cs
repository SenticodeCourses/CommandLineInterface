using System.Diagnostics;
using CommandLineInterface;
using CommandLineInterface.Attributes;
using CommandLineInterface.Enums;

namespace SampleApplication.App
{
    public partial class AppCommands : AppCommandsBase
    {
        //SAY COMMAND
        [SubscriptionCommand(nameof(Say), "help_FirstCommand")]
        public Command Say => _say ??
            (_say = new Command(ExecuteSay, CanExecuteSay));

        Command _say;
        
        void ExecuteSay()
        {
            ConsoleHelper.WriteLine("sucsess", MessageTypes.CommandResult);
        }
        
        bool CanExecuteSay()
        {
            return true;
        }


        //EXIT COMMAND
        [SubscriptionCommand(nameof(Exit), "help_Exit", PriorityType.High)]
        public Command Exit => _exit ??
            (_exit = new Command(ExecuteExit, CanExecuteExit));

        Command _exit;

        void ExecuteExit()
        {
            Process.GetCurrentProcess().Kill();
        }

        bool CanExecuteExit()
        {
            return true;
        }
    }
}
