using System;
using CommandLineInterface.Enums;

namespace CommandLineInterface.Attributes
{
    /// <summary>
    ///     Subscribes commands.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SubscriptionCommandAttribute : Attribute
    {
        public SubscriptionCommandAttribute(string commandName, string help,
            PriorityType priority = PriorityType.Low)
        {
            CommandName = commandName.ToLower();
            Help = help;
            Priority = priority;
        }

        /// <summary>
        ///     Gets command name.
        /// </summary>
        public string CommandName { get; }
        /// <summary>
        ///     Gets command help.
        /// </summary>
        public string Help { get; }
        /// <summary>
        ///     Gets command priority.
        /// </summary>
        public PriorityType Priority { get; }
    }
}
