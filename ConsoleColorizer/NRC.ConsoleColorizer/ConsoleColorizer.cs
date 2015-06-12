using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NRC.ConsoleColorizer
{
    public class ConsoleColorizer : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                var colorArgs =
                    args.FirstOrDefault(c => c.GetType() == typeof (ConsoleColorArgument)) as ConsoleColorArgument;

                var priorForegroundColor = ConsoleColor.Black;
                var priorBackgroundColor = ConsoleColor.Black;


                priorForegroundColor = SetandPreserveConsoleColors(colorArgs, priorForegroundColor,
                    ref priorBackgroundColor);


                if (colorArgs != null)
                {
                    var argList = new List<object>(args);
                    argList.Remove(colorArgs);
                    args = argList.ToArray();
                }
                typeof (Console).GetMethod(binder.Name, args.Select(c => c.GetType()).ToArray())
                    .Invoke(null, args);
                result = false;

                ResetConsoleColor(colorArgs, priorForegroundColor, priorBackgroundColor);
                return true;
            }
            catch (Exception)
            {
                result = false;

                return base.TryInvokeMember(binder, args, out result);
            }
        }

        private ConsoleColor SetandPreserveConsoleColors(ConsoleColorArgument colorArgs,
            ConsoleColor priorForegroundColor,
            ref ConsoleColor priorBackgroundColor)
        {
            if (colorArgs != null)
            {
                

                GetValue(colorArgs, out priorForegroundColor, out priorBackgroundColor);
            }
            return priorForegroundColor;
        }

        public void XYZ()
        {
            
        }
        private void ResetConsoleColor(ConsoleColorArgument colorArgs, ConsoleColor priorForegroundColor,
            ConsoleColor priorBackgroundColor)
        {
            if (colorArgs != null)
            {
                SetNewAndPreserveColor(() => Console.ForegroundColor,
                    priorForegroundColor);

                SetNewAndPreserveColor(() => Console.BackgroundColor,
                    priorBackgroundColor);
            }
        }

        private void GetValue(ConsoleColorArgument consoleColors, out ConsoleColor priorForegroundColor,
            out ConsoleColor priorBackgroundColor)
        {
            priorForegroundColor = SetNewAndPreserveColor(() => Console.ForegroundColor,
                consoleColors.ForegroundColor);
            priorBackgroundColor = SetNewAndPreserveColor(() => Console.BackgroundColor,
                consoleColors.BackgroundColor);
        }

        private ConsoleColor SetNewAndPreserveColor(Expression<Func<ConsoleColor>> colorProperty, ConsoleColor color)
        {
            var expr = (MemberExpression) colorProperty.Body;
            var prop = (PropertyInfo) expr.Member;
            var retVal = (ConsoleColor) prop.GetValue(prop);
            prop.SetValue(prop, color, null);
            return retVal;
        }
    }
}