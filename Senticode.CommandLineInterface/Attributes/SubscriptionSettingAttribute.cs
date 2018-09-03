using System;

namespace CommandLineInterface.Attributes
{
    /// <summary>
    ///     Subscribes settings.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SubscriptionSettingAttribute : Attribute
    {
        public SubscriptionSettingAttribute(string settingName, string help)
        {
            SettingName = settingName.ToLower();
            Help = help;
        }

        /// <summary>
        ///     Gets setting name.
        /// </summary>
        public string SettingName { get; }
        /// <summary>
        ///     Gets setting help.
        /// </summary>
        public string Help { get; }
    }
}
