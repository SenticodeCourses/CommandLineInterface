using System;

namespace CommandLineInterface.Exceptions
{
    internal class InputCommandException : Exception
    {
        public InputCommandException(string command) :
            base($"Input [{command}] is wrong.")
        {
            
        }
    }
}
