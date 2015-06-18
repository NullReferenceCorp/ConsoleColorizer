using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NRC.ConsoleColorizer
{
    /// <summary>
    ///     This class is used to swap out and preserve the existing <see cref="Console.ForegroundColor" /> and
    ///     <see cref="Console.BackgroundColor" /> of the console.
    /// </summary>
    internal class ConsoleHelper
    {
        private readonly ConsoleColor _priorBackgroundColor;
        private readonly ConsoleColor _priorForegroundColor;

        public ConsoleHelper()
        {
            _priorForegroundColor = Console.ForegroundColor;
            _priorBackgroundColor = Console.BackgroundColor;
        }

        internal void ResetConsoleColor()
        {
            Console.ForegroundColor = _priorForegroundColor;
            Console.BackgroundColor = _priorBackgroundColor;
        }

        internal void SetandPreserveConsoleColors(ConsoleColorArgument colorArgs)
        {
            if (colorArgs == null) return;

            SetNewAndPreserveColor(() => Console.ForegroundColor,
                colorArgs.ForegroundColor);
            SetNewAndPreserveColor(() => Console.BackgroundColor,
                colorArgs.BackgroundColor);
        }

        internal ConsoleColor SetNewAndPreserveColor(Expression<Func<ConsoleColor>> colorProperty,
            ConsoleColor color)
        {
            var expr = (MemberExpression) colorProperty.Body;
            var prop = (PropertyInfo) expr.Member;
            var retVal = (ConsoleColor) prop.GetValue(prop);
            prop.SetValue(prop, color, null);
            return retVal;
        }
    }
}