using System;

namespace NRC.ConsoleColorizer
{
    public class ConsoleColorArgument
    {
        public ConsoleColorArgument(ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            if (foregroundColor.HasValue)
            {
                ForegroundColor = foregroundColor.GetValueOrDefault(Console.ForegroundColor);
            }
            if (backgroundColor.HasValue)
            {
                BackgroundColor = backgroundColor.GetValueOrDefault(Console.BackgroundColor);
            }
        }

      
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
    }
}