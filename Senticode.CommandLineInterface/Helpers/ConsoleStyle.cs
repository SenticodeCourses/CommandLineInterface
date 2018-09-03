using System;

namespace CommandLineInterface.Helpers
{
    internal struct ConsoleStyle
    {
        public ConsoleStyle(ConsoleColor font, ConsoleColor background)
        {
            Font = font;
            Background = background;
        }

        public ConsoleColor Font { get; }
        public ConsoleColor Background { get; }
    }
}
