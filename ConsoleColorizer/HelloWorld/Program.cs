using System;
using NRC.ConsoleColorizer;

namespace HelloWorld
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            //Example using Dynamic ConsoleColorArgument
            dynamic dynamicConsole = new DynamicConsoleColorizer();

            dynamicConsole.WriteLine("Hey there, I am the default.");
            dynamicConsole.WriteLine(new ConsoleColorArgument(ConsoleColor.Blue), "HI BLUE");
            dynamicConsole.Write(new ConsoleColorArgument(ConsoleColor.Red, ConsoleColor.DarkGreen), "Hi I'm Red on a Dark Green Background");
            dynamicConsole.Write("I'm Normal. and on the same line.");
            dynamicConsole.WriteLine(new ConsoleColorArgument(ConsoleColor.DarkYellow, ConsoleColor.Cyan),
                "I'm not normal!!");

            Console.WriteLine("I'm a standard Console.WriteLine()");

            //Example Using ColoredConsoleWrapper

            ColoredConsoleWrapper.Write(new ConsoleColorArgument(ConsoleColor.Blue), () => Console.WriteLine("hi in blue"));
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(ConsoleColor.Blue,ConsoleColor.DarkGreen), () => Console.WriteLine("hi in blue on GREEN!"));

            //Using ColoredConsole

            //Verbose Mode
            ColoredConsole.WriteLine("Blue on Red Verbose",new ConsoleColorArgument(ConsoleColor.Blue,ConsoleColor.Red));

            //
            ColoredConsole.WriteLine("Blue on Red Tearse", ConsoleColor.Blue, ConsoleColor.Red);

            ColoredConsole.WriteLine("Blue on Default", ConsoleColor.Blue);

        }
    }
}