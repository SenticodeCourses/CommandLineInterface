using System;

namespace CommandLineInterface.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SubscriptionSettingAttribute : Attribute
    {
        public SubscriptionSettingAttribute(string settingName, string help)
        {
            SettingName = "-" + settingName.ToLower();
            Help = help;
        }

        public string SettingName { get; }
        public string Help { get; }
    }
}
