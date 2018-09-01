using System;
using CommandLineInterface.Enums;

namespace CommandLineInterface.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SubscriptionCommandAttribute : Attribute
    {
        public SubscriptionCommandAttribute(string commandName, string help,
            PriorityType priority = PriorityType.Low)
        {
            CommandName = "-" + commandName.ToLower();
            Help = help;
            Priority = priority;
        }

        public string CommandName { get; }
        public string Help { get; }
        public PriorityType Priority { get; }
    }
}
