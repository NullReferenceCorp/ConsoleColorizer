using System;
using NRC.ConsoleColorizer;

namespace HelloWorld
{
    internal class Program
    {
        public static dynamic DynamicConsole = new DynamicConsoleColorizer();

        private static void Main(string[] args)
        {
            //Example using Dynamic ConsoleColorArgument

            DynamicConsole.WriteLine("Hey there, I am the default.");
            DynamicConsole.WriteLine(new ConsoleColorArgument(ConsoleColor.Blue), "HI BLUE");
            DynamicConsole.Write(new ConsoleColorArgument(ConsoleColor.Red,ConsoleColor.DarkGreen), "Hi I'm Red on a Dark Green Background");
            DynamicConsole.Write("I'm Normal. and on the same line.");
            DynamicConsole.WriteLine(new ConsoleColorArgument(ConsoleColor.DarkYellow, ConsoleColor.Cyan),
                "I'm not normal!!");

            Console.WriteLine("I'm a standard Console.WriteLine()");


        }
    }
}