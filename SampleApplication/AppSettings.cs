using System;
using System.Threading.Tasks;
using CommandLineInterface;
using CommandLineInterface.Attributes;

namespace SampleApplication
{
    public class AppSettings : AppSettingsBase
    {
        [SubscriptionSetting("-number", "help")]
        public object Number { get; set; }

        public override bool Validate(string command, string[] parameters, out object value)
        {
            throw new NotImplementedException();
        }
    }
}
