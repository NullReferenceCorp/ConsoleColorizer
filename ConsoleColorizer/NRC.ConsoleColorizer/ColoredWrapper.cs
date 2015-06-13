using System;

namespace NRC.ConsoleColorizer
{
    public static class ColoredConsoleWrapper
    {
        public static void Write(ConsoleColorArgument colorArgument, Action action)
        {
            var consoleHelper = new ConsoleHelper();
            consoleHelper.SetandPreserveConsoleColors(colorArgument);
            action();
            consoleHelper.ResetConsoleColor();
        }
    }
}