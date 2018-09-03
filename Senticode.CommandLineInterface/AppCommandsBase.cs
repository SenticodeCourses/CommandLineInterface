using CommandLineInterface.Attributes;
using CommandLineInterface.Commands;
using CommandLineInterface.Enums;

namespace CommandLineInterface
{
    /// <summary>
    ///     This class contains global commands.
    /// </summary>
    public abstract class AppCommandsBase<TSettings>
        where TSettings : AppSettingsBase
    {
        protected AppCommandsBase(TSettings settings)
        {
            AppSettings = settings;
            ExitCommand = new ExitCommand<TSettings>(settings);
        }

        /// <summary>
        ///     Gets global application settings.
        /// </summary>
        public TSettings AppSettings { get; set; }

        /// <summary>
        ///     Command execute exit application method.
        /// </summary>
        [SubscriptionCommand("-exit", "Command execute exit application method.", PriorityType.High)]
        public Command ExitCommand { get; }

        /// <summary>
        ///     Command shows application help.
        /// </summary>
        [SubscriptionCommand("-help", "help_FirstCommand")]
        public Command HelpCommand { get; } = new HelpCommand();
    }
}