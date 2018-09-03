using System;
using System.Collections.Generic;

namespace CommandLineInterface.Infrastructure
{
    internal class CommandParserResult
    {
        public CommandParserResult(IEnumerable<CommandInput> commands,
            Exception exception = null)
        {
            Commands = commands;
            Exception = exception;
        }

        public IEnumerable<CommandInput> Commands { get; }
        public bool IsSuccessful => Exception == null; 
        public Exception Exception { get; }
    }
}
