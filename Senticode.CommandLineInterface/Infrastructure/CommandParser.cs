using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommandLineInterface.Exceptions;

namespace CommandLineInterface.Infrastructure
{
    internal class CommandParser
    {
        const string RegexString = "^-[a-z]{1,20}$";

        public CommandParserResult Parse(string input)
        {
            var commands = new List<CommandInput>();
            string[] commandLines = input.Trim().Split(';');
            var regex = new Regex(RegexString);
            List<Exception> exceptions = new List<Exception>();

            foreach (var line in commandLines)
            {
                var words = line.Trim().Split();
                words = words.Select(x => x.Trim()).ToArray();
                var parameters = new string[words.Length - 1];
                Array.Copy(words, 1, parameters, 0, words.Length - 1);

                if (regex.IsMatch(words[0]))
                {
                    commands.Add(new CommandInput(words[0], parameters));
                }
                else if (words[0] != "")
                {
                    exceptions.Add(new InputCommandException(words[0]));
                }
            }

            return new CommandParserResult(commands, exceptions.Count > 0 ?
                    (exceptions.Count == 1 ?
                        exceptions.First() : new MultiplyException(exceptions)
                    ) : null);
        }
    }
}
