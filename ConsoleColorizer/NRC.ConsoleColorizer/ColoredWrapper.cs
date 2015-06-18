using System;
using System.Threading.Tasks;

namespace NRC.ConsoleColorizer
{
    /// <summary>
    ///     This is a wrapper that allows you to set <see cref="Console" /> output colors via
    ///     <see cref="ConsoleColorArgument" /> and execute an arbitrary code block.
    /// </summary>
    public static class ColoredConsoleWrapper
    {
        /// <summary>
        ///     Sets console color configuration and executions an action.
        /// </summary>
        /// <param name="colorArgument">
        ///     The color configuration for the <see cref="Console" /> to use while executing the code
        ///     block.
        /// </param>
        /// <param name="action">The action to execute.</param>
        /// <example>
        ///     <code>
        ///         ColoredConsoleWrapper.Write(new ConsoleColorArgument(ConsoleColor.Blue), () => Console.WriteLine("hi in blue"));
        ///         ColoredConsoleWrapper.Write(new ConsoleColorArgument(ConsoleColor.Blue, ConsoleColor.DarkGreen), () => Console.WriteLine("hi in blue on GREEN!"));
        ///   </code>
        /// </example>
        public static void Write(ConsoleColorArgument colorArgument, Action action)
        {
            var consoleHelper = new ConsoleHelper();
            consoleHelper.SetandPreserveConsoleColors(colorArgument);
            action();
            consoleHelper.ResetConsoleColor();
        }

        /// <summary>
        ///     Sets console color configuration and executions an action asynchronously.
        /// </summary>
        /// <param name="colorArgument">
        ///     The color configuration for the <see cref="Console" /> to use while executing the code
        ///     block.
        /// </param>
        /// <param name="action">The action to execute.</param>
        /// <example>
        ///     <code>
        ///    async () => await ColoredConsoleWrapper.WriteAsync(
        ///      new ConsoleColorArgument(ConsoleColor.Blue, ConsoleColor.DarkGreen),
        ///       async () =>
        ///      {
        ///         Console.Write("I am pausing for 3 seconds...");
        ///         await Task.Delay(TimeSpan.FromSeconds(3)); //Simulate Blocking
        ///         Console.WriteLine("Done.");
        ///         ColoredConsole.WriteLine("I can even nest this!", ConsoleColor.DarkRed, ConsoleColor.Gray);
        ///         Console.WriteLine("Back to original color configuration!");
        ///      })
        ///   </code>
        /// </example>
        public static async Task Write(ConsoleColorArgument colorArgument, Func<Task> action)
        {
            var consoleHelper = new ConsoleHelper();
            consoleHelper.SetandPreserveConsoleColors(colorArgument);
            await action();
            consoleHelper.ResetConsoleColor();
        }
    }
}