using System;
using System.Collections.Generic;
using System.Text;

namespace CommandLineInterface.Exceptions
{
    public class MultiplyException : Exception
    {
        public MultiplyException(IEnumerable<Exception> exceptions) :
            this(ToMessage(exceptions))
        {
            Exceptions = exceptions;
        }

        MultiplyException(string message) : base(message)
        {

        }

        public IEnumerable<Exception> Exceptions { get; }

        static string ToMessage(IEnumerable<Exception> exceptions)
        {
            var message = new StringBuilder();
            message.AppendLine("Errors:");

            foreach (var ex in exceptions)
            {
                message.AppendLine(ex.Message);
            }

            return message.ToString();
        }
        
    }
}
