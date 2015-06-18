using System;

namespace NRC.ConsoleColorizer
{
    /// <summary>
    ///     This class holds <see cref="Console"/> color configuration.
    /// </summary>
    public class ConsoleColorArgument
    {
        /// <summary>
        ///     This constructor allows you to set both the <see cref="Console.ForegroundColor" /> and
        ///     <see cref="Console.BackgroundColor" /> of the function call.
        /// </summary>
        /// <param name="foregroundColor">
        ///     This is the <see cref="ConsoleColor" /> that is to be mapped to <see cref="Console.ForegroundColor" />
        ///     <para>
        ///         If this parameter is  null, it is ignored and nothing is set.
        ///     </para>
        /// </param>
        /// <param name="backgroundColor">
        ///     This is the <see cref="ConsoleColor" /> that is to be mapped to <see cref="Console.BackgroundColor" />
        ///     <para>
        ///         If this parameter is  null, it is ignored and nothing is set.
        ///     </para>
        /// </param>
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


        /// <summary>
        ///     This is the <see cref="ConsoleColor" /> that is to be mapped to <see cref="Console.ForegroundColor" />
        /// </summary>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        ///     This is the <see cref="ConsoleColor" /> that is to be mapped to <see cref="Console.BackgroundColor" />
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }
    }
}