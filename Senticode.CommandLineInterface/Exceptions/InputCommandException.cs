using System;

namespace CommandLineInterface.Exceptions
{
    public class InputCommandException : Exception
    {
        public InputCommandException(string command) :
            base($"Input [{command}] is wrong.")
        {
            
        }
    }
}
