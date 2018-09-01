using System;

namespace CommandLineInterface.Exceptions
{
    public class NotFoundCommandException : Exception
    {
        public NotFoundCommandException(string commandName) :
            base($"Command [{commandName}] not found.")
        {
            
        }
    }
}
