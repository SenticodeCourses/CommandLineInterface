using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CommandLineInterface.Attributes;

namespace CommandLineInterface.Helpers
{
    public class CommandsHelper
    {
        public static Dictionary<string, CommandInfo> GetCommands(object commandsHolder)
        {
            var type = commandsHolder.GetType();
            var result = type.GetProperties()
                .Where(x => x.GetCustomAttribute<SubscriptionCommandAttribute>() != null)
                .Where(x => x.PropertyType == typeof(Command))
                .ToDictionary(key => key.GetCustomAttribute<SubscriptionCommandAttribute>().CommandName, value =>
                    ConvertToCommnadInfo(value, commandsHolder));

            return result;
        }

        public static Dictionary<string, SettingInfo> GetSettings(object commandsHolder)
        {
            var type = commandsHolder.GetType();
            var result = type.GetProperties()
                .Where(x => x.GetCustomAttribute<SubscriptionSettingAttribute>() != null)
                .Where(x => x.PropertyType != typeof(Command))
                .ToDictionary(key => key.GetCustomAttribute<SubscriptionSettingAttribute>().SettingName, value =>
                    ConvertToSettingInfo(value, commandsHolder));

            return result;
        }

        static CommandInfo ConvertToCommnadInfo(PropertyInfo prop, object commandsHolder)
        {
            var info = prop.GetCustomAttribute<SubscriptionCommandAttribute>();
            var value = prop.GetValue(commandsHolder);
            return new CommandInfo((Command)value, info);
        }

        static SettingInfo ConvertToSettingInfo(PropertyInfo prop, object commandsHolder)
        {
            var info = prop.GetCustomAttribute<SubscriptionSettingAttribute>();
            var value = prop.GetValue(commandsHolder);
            return new SettingInfo(value, info);
        }
    }
}
