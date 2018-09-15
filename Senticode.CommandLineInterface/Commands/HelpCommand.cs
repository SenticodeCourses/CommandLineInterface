using System;
using System.Collections.Generic;
using CommandLineInterface.Enums;
using CommandLineInterface.Helpers;

namespace CommandLineInterface.Commands
{
    internal class HelpCommand<TSettings> : Command
        where TSettings : AppSettingsBase
    {
        private static Dictionary<string, CommandInfo> _commands;

        static void Execute()
        {
            foreach (var command in _commands)
            {
                ConsoleHelper.WriteLine(command.Key + ": " + command.Value.Info.Help, MessageTypes.Help);
            }
        }

        public HelpCommand(AppCommandsBase<TSettings> appCommands) : this(Execute, () => true)
        {
            _commands = CommandsHelper.GetCommands(appCommands);
        }

        private HelpCommand(Action executeCommandName, Func<bool> canExecuteCommandName = null) :
            base(executeCommandName, canExecuteCommandName)
        {

        }
    }
}
