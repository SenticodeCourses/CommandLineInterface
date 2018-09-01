using System;
using System.Text;
using System.Threading.Tasks;
using CommandLineInterface;
using CommandLineInterface.Enums;
using CommandLineInterface.Exceptions;
using CommandLineInterface.Infrastructure;

namespace SampleApplication.App
{
    public class Application : ApplicationBase<AppSettings, AppCommands>
    {
        CommandParser _commandParser;
        CommandExecuter<AppSettings, AppCommands> _commandExcuter;

        Application() : base(new AppSettings(), new AppCommands())
        {

        }

        public override void Initialize()
        {
            _commandParser = new CommandParser();
            _commandExcuter = new CommandExecuter<AppSettings, AppCommands>(this);
            Task.Run(async () => await _commandExcuter.RunSchedulerAsync());
        }

        public override void Run()
        {
            while (true)
            {
                var args = Console.ReadLine();
                ExecuteIteration(args);
            }
        }

        public override void Run(string[] args)
        {
            if (args.Length > 0)
            {
                var content = new StringBuilder();

                foreach (var arg in args)
                {
                    content.Append(arg.Trim());
                    content.Append(" ");
                }

                ExecuteIteration(content.ToString().Trim());
            }

            Run();
        }

        public void AbortAllCommands()
        {
            _commandExcuter.ClearScheduler();
        }
        
        public static Application Instance { get; } = new Application();
        
        void ExecuteIteration(string input)
        {
            var commandsInput = _commandParser.Parse(input);

            if (commandsInput.IsSuccessful)
            {
                var exception = _commandExcuter.AddCommands(commandsInput);

                if (exception != null) //TODO EM: analyse this
                {
                    AbortAllCommands();
                    ConsoleHelper.WriteLine(exception.Message, MessageTypes.Error);
                }
            }
            else
            {
                ConsoleHelper.WriteLine(commandsInput.Exception.Message,
                    MessageTypes.Error);
            }
        }
    }
}
