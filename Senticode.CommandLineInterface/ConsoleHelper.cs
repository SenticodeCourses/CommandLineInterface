using System;
using System.Collections.Generic;
using CommandLineInterface.Enums;
using CommandLineInterface.Helpers;

namespace CommandLineInterface
{
    internal static class ConsoleHelper
    {
        static readonly Dictionary<MessageTypes, ConsoleStyle> ConsoleColors =
            new Dictionary<MessageTypes, ConsoleStyle>
            {
                [MessageTypes.CommandResult] = new ConsoleStyle(ConsoleColor.Cyan, ConsoleColor.Black),
                [MessageTypes.Help] = new ConsoleStyle(ConsoleColor.Green, ConsoleColor.Black),
                [MessageTypes.Error] = new ConsoleStyle(ConsoleColor.Red, ConsoleColor.Black),
                [MessageTypes.Warning] = new ConsoleStyle(ConsoleColor.Yellow, ConsoleColor.Black),
                [MessageTypes.SettingSet] = new ConsoleStyle(ConsoleColor.Black, ConsoleColor.Gray),
                [MessageTypes.System] = new ConsoleStyle(ConsoleColor.Gray, ConsoleColor.Black)
            };

        public static void Write(string value, MessageTypes type)
        {
            SetColors(type);
            Console.Write(value);
            ResetColors();
        }

        public static void WriteLine(string value, MessageTypes type)
        {
            SetColors(type);
            Console.WriteLine(value);
            ResetColors();
        }

        static void SetColors(MessageTypes type)
        {
            Console.ForegroundColor = ConsoleColors[type].Font;
            Console.BackgroundColor = ConsoleColors[type].Background;
        }

        static void ResetColors()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
