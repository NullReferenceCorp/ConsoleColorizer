using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace NRC.ConsoleColorizer
{
    /// <summary>
    ///     DynamicConsoleColorizer is a simple wrapper for System.Console that looks for color commands in the form of a
    ///     <see cref="ConsoleColorArgument" /> argument
    ///     that can be located in any argument position.
    /// </summary>
    public class DynamicConsoleColorizer : DynamicObject
    {
        private readonly ConsoleHelper _consoleHelper = new ConsoleHelper();

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
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
                typeof (Console).GetMethod(binder.Name, args.Select(c => c.GetType()).ToArray())
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