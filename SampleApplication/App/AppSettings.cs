using System;
using CommandLineInterface;
using CommandLineInterface.Attributes;

namespace SampleApplication.App
{
    public class AppSettings : AppSettingsBase
    {
        [SubscriptionSetting(nameof(Number), "help")]
        public object Number { get; set; }

        public override bool Validate(string command, string[] parameters, out object value)
        {
            throw new NotImplementedException();
        }
    }
}
