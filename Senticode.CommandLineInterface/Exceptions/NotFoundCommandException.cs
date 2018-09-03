using System;

namespace CommandLineInterface.Exceptions
{
    internal class NotFoundCommandException : Exception
    {
        public NotFoundCommandException(string commandName) :
            base($"Command [{commandName}] not found.")
        {
            
        }
    }
}
