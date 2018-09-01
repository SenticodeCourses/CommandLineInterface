using CommandLineInterface.Attributes;

namespace CommandLineInterface.Helpers
{
    public class CommandInfo
    {
        public CommandInfo(Command command, SubscriptionCommandAttribute info)
        {
            Command = command;
            Info = info;
        }

        public Command Command { get; }
        public SubscriptionCommandAttribute Info { get; }
    }
}