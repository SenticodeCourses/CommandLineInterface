using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLineInterface;
using CommandLineInterface.Enums;
using Senticode.AppEnvironment.Common.Interfaces;

namespace SampleApplication.Services
{
    internal class ConsoleLogger : ILogger
    {
        public ConsoleLogger(IIoCContainer container)
        {
            container.RegisterInstance<ILogger>(this);
        }

        public void WriteLog(string log)
        {
            ConsoleHelper.WriteLine(log, MessageTypes.System);
        }

        public void WriteResult(string result)
        {
            ConsoleHelper.WriteLine(result, MessageTypes.CommandResult);
        }

        public void WriteInformation(string information)
        {
            ConsoleHelper.WriteLine(information, MessageTypes.Warning);
        }

        public void WriteException(Exception exception)
        {
            ConsoleHelper.WriteLine(exception.Message, MessageTypes.Error);
        }
    }
}
