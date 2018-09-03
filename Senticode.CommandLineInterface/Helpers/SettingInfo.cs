using CommandLineInterface.Attributes;

namespace CommandLineInterface.Helpers
{
    internal class SettingInfo
    {
        public SettingInfo(object setting, SubscriptionSettingAttribute info)
        {
            Setting = setting;
            Info = info;
        }

        public object Setting { get; }
        public SubscriptionSettingAttribute Info { get; }
    }
}
