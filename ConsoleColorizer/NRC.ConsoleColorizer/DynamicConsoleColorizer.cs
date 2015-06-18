using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace NRC.ConsoleColorizer
{
    /// <summary>
    ///     DynamicConsoleColorizer is a proxy for System.Console that looks for color commands in the form of a
    ///     <see cref="ConsoleColorArgument" /> argument
    ///     that can be located in any argument position.
    /// </summary>
    /// <example>
    ///     This sample shows how to use the <see cref="DynamicConsoleColorizer" />
    ///     <code> 
    ///         var console = new DynamicConsoleColorizer();
    ///         dynamicConsole.WriteLine("Hey there, I am the default.");
    ///         dynamicConsole.WriteLine(new ConsoleColorArgument(ConsoleColor.Blue), "HI BLUE");
    ///         dynamicConsole.Write(new ConsoleColorArgument(ConsoleColor.Red, ConsoleColor.DarkGreen), "Hi I'm Red on a Dark Green Background");
    ///         dynamicConsole.Write("I'm Normal. and on the same line.");
    ///         dynamicConsole.WriteLine(new ConsoleColorArgument(ConsoleColor.DarkYellow, ConsoleColor.Cyan), "I'm not normal!!");
    /// </code>
    /// </example>
    public class DynamicConsoleColorizer : DynamicObject
    {
        private readonly ConsoleHelper _consoleHelper = new ConsoleHelper();
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            try
            {
                var colorArgs =
                    args.FirstOrDefault(c => c.GetType() == typeof (ConsoleColorArgument)) as ConsoleColorArgument;


                _consoleHelper.SetandPreserveConsoleColors(colorArgs);


                if (colorArgs != null)
                {
                    var argList = new List<object>(args);
                    argList.Remove(colorArgs);
                    args = argList.ToArray();
                }
                typeof (Console)
                    .GetMethod(binder.Name, args.Select(c => c.GetType()).ToArray())
                    .Invoke(null, args);
                result = false;

                _consoleHelper.ResetConsoleColor();
                return true;
            }
            catch (Exception)
            {
                result = false;

                return base.TryInvokeMember(binder, args, out result);
            }
            finally
            {
                _consoleHelper.ResetConsoleColor();
            }
        }
    }
}