using System;
using System.Text;
using System.Threading.Tasks;
using CommandLineInterface.Enums;
using CommandLineInterface.Infrastructure;

namespace CommandLineInterface
{
    /// <summary>
    ///     This class initialize and run CLI process.
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    /// <typeparam name="TCommands"></typeparam>
    public abstract class ApplicationBase<TSettings, TCommands>
        where TSettings : AppSettingsBase
        where TCommands : AppCommandsBase<TSettings>
    {

        CommandParser _commandParser;
        CommandExecuter<TSettings, TCommands> _commandExcuter;

        protected ApplicationBase(TSettings appSettingsBase, TCommands appCommandsBase)
        {
            AppSettings = appSettingsBase;
            AppCommands = appCommandsBase;
        }

        /// <summary>
        ///     Run cycle input/output.
        /// </summary>
        public virtual void Run()
        {
            while (true)
            {
                var args = Console.ReadLine();
                ExecuteIteration(args);
            }
        }

        /// <summary>
        ///     Run cycle input/output and handle command line arguments.
        /// </summary>
        /// <param name="args"></param>
        public virtual void Run(string[] args)
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

        /// <summary>
        ///     Initialize CLI process.
        /// </summary>
        public virtual void Initialize()
        {
            _commandParser = new CommandParser();
            _commandExcuter = new CommandExecuter<TSettings, TCommands>(this);
            Task.Run(async () => await _commandExcuter.RunSchedulerAsync());
        }

        /// <summary>
        ///     Abort all commands in process queue.
        /// </summary>
        public virtual void AbortAllCommands()
        {
            _commandExcuter.ClearScheduler();
        }

        /// <summary>
        ///     Gets object with CLI settings.
        /// </summary>
        public TSettings AppSettings { get; }
        /// <summary>
        ///     Gets object with CLI commands.
        /// </summary>
        public TCommands AppCommands { get; }

        protected void ExecuteIteration(string input)
        {
            var commandsInput = _commandParser.Parse(input);

            if (commandsInput.IsSuccessful)
            {
                var exception = _commandExcuter.AddCommands(commandsInput);

                if (exception != null)
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
