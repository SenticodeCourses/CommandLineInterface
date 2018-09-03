using System;
using CommandLineInterface.Enums;

namespace CommandLineInterface.Commands
{
    internal class HelpCommand : Command
    {
        static void Execute()
        {
            ConsoleHelper.WriteLine("sucsess", MessageTypes.CommandResult);
        }

        public HelpCommand() : this(Execute, () => true)
        {
            
        }

        private HelpCommand(Action executeCommandName, Func<bool> canExecuteCommandName = null) :
            base(executeCommandName, canExecuteCommandName)
        {

        }
    }
}
