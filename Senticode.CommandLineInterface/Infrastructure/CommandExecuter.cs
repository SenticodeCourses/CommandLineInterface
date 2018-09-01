using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CommandLineInterface.Attributes;
using CommandLineInterface.Enums;
using CommandLineInterface.Exceptions;
using CommandLineInterface.Helpers;

namespace CommandLineInterface.Infrastructure
{
    public class CommandExecuter<TSettings, TCommands>
        where TSettings : AppSettingsBase
        where TCommands : AppCommandsBase
    {
        readonly Queue<CommandInfo> _commandsQueue = new Queue<CommandInfo>();
        readonly Dictionary<string, CommandInfo> _commands;
        readonly Dictionary<string, SettingInfo> _settings;
        bool _isWorking;
        readonly TSettings _appSettings;

        public CommandExecuter(ApplicationBase<TSettings, TCommands> application)
        {
            _appSettings = application.AppSettings;
            _commands = CommandsHelper.GetCommands(application.AppCommands);
            _settings = CommandsHelper.GetSettings(application.AppSettings);
        }

        public Exception AddCommands(CommandParserResult args)
        {
            var exceptions = new List<Exception>();

            foreach (var comInput in args.Commands)
            {
                if (_commands.ContainsKey(comInput.CommandName))
                {
                    lock (_commandsQueue)
                    {
                        var comInfo = _commands[comInput.CommandName];

                        if (comInfo.Info.Priority == PriorityType.High)
                        {
                            ClearScheduler();
                        }

                        _commandsQueue.Enqueue(comInfo);
                    }
                }
                else if (_settings.ContainsKey(comInput.CommandName))
                {
                    SetSetting(comInput.CommandName, comInput.Params);
                }
                else
                {
                    exceptions.Add(new NotFoundCommandException(comInput.CommandName));
                }
            }

            if (exceptions.Count == 1)
            {
                return exceptions.First();
            }
            else if (exceptions.Count > 1)
            {
                return new MultiplyException(exceptions);
            }

            if (!_isWorking)
            {
                Task.Run(async () => await RunSchedulerAsync());
            }

            return null;
        }

        public async Task RunSchedulerAsync()
        {
            _isWorking = true;
            int count;

            lock (_commandsQueue)
            {
                count = _commandsQueue.Count;
            }

            while (count > 0)
            {
                CommandInfo comInfo;

                lock (_commandsQueue)
                {
                    comInfo = _commandsQueue.Dequeue(); 
                }

                await Execute(comInfo);

                lock (_commandsQueue)
                {
                    count = _commandsQueue.Count;
                }
            }

            _isWorking = false;
        }

        public void ClearScheduler()
        {
            lock (_commandsQueue)
            {
                _commandsQueue.Clear();
            }
        }
        
        async Task Execute(CommandInfo comInfo)
        {
            await Task.Run(() =>
            {
                if (comInfo.Command.CanExecute())
                {
                    _commands[comInfo.Info.CommandName].Command.Execute();
                }
            });
        }

        void SetSetting(string name, string[] param)
        {
            var property = _appSettings.GetType().GetProperties()
                .Where(x =>
                    x.GetCustomAttribute<SubscriptionSettingAttribute>().SettingName == name)
                .ToArray().First();

            if (param.Length > 0)
            {
                property.SetValue(_appSettings, param);
            }
            else
            {
                ConsoleHelper.WriteLine(name + ": " + property.GetValue(_appSettings), MessageTypes.SettingSet);
            }
        }
    }
}
