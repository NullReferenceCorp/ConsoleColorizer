using System;

namespace NRC.ConsoleColorizer
{
    public static class ColoredConsole
    {
        public static void WriteLine(bool value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(value));
        }

        public static void WriteLine(char value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(value));
        }

        public static void WriteLine(char[] buffer, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(buffer));
        }

        public static void WriteLine(char[] buffer, int index, int count, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(buffer, index, count));
        }

        public static void WriteLine(decimal value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(value));
        }

        public static void WriteLine(double value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(value));
        }

        public static void WriteLine(float value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(value));
        }

        public static void WriteLine(int value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(value));
        }

        public static void WriteLine(uint value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(value));
        }

        public static void WriteLine(long value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            Console.WriteLine(value);
        }

        public static void WriteLine(ulong value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(value));
        }

        public static void WriteLine(object value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(value));
        }

        public static void WriteLine(string value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(value));
        }

        public static void WriteLine(string format, object arg0, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(format, arg0));
        }

        public static void WriteLine(string format, object arg0, object arg1, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(format, arg0, arg1));
        }

        public static void WriteLine(string format, object arg0, object arg1, object arg2
            , ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.WriteLine(format, arg0, arg1, arg2));
        }

        public static void WriteLine(string format, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null, params object[] arg)
        {
            if (arg == null) // avoid ArgumentNullException from string.Format 
                ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                    () => Console.WriteLine(format, null, null));
            // faster than Console.WriteLine(format, (object)arg);
            else
                ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                    () => Console.WriteLine(format, arg));
        }

        public static void Write(string format, object arg0, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(format, arg0));
        }

        public static void Write(string format, object arg0, object arg1, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(format, arg0, arg1));
        }

        public static void Write(string format, object arg0, object arg1, object arg2
            , ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(format, arg0, arg1, arg2));
        }

        public static void Write(string format, object arg0, object arg1, object arg2, object arg3
            , ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null, __arglist)
        {
            object[] objArgs;
            int argCount;

            var args = new ArgIterator(__arglist);

            //+4 to account for the 4 hard-coded arguments at the beginning of the list. 
            argCount = args.GetRemainingCount() + 4;

            objArgs = new object[argCount];

            //Handle the hard-coded arguments
            objArgs[0] = arg0;
            objArgs[1] = arg1;
            objArgs[2] = arg2;
            objArgs[3] = arg3;

            //Walk all of the args in the variable part of the argument list. 
            for (var i = 4; i < argCount; i++)
            {
                objArgs[i] = TypedReference.ToObject(args.GetNextArg());
            }

            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(format, objArgs));
        }

        public static void Write(string format, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null, params object[] arg)
        {
            if (arg == null) // avoid ArgumentNullException from string.Format
                ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                    () => Console.Write(format, null, null));
            // faster than Console.Write(format, (object)arg); 
            else
                ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                    () => Console.Write(format, arg));
        }

        public static void Write(bool value, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        public static void Write(char value, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        public static void Write(char[] buffer, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(buffer));
        }

        public static void Write(char[] buffer, int index, int count, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(buffer, index, count));
        }

        public static void Write(double value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        public static void Write(decimal value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        public static void Write(float value, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        public static void Write(int value, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        public static void Write(uint value, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        public static void Write(long value, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        public static void Write(ulong value, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        public static void Write(object value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        public static void Write(string value, ConsoleColor? foregroundColor = null,
            ConsoleColor? backgroundColor = null)
        {
            ColoredConsoleWrapper.Write(new ConsoleColorArgument(foregroundColor, backgroundColor),
                () => Console.Write(value));
        }

        #region Writes with Verbose ConsoleColorArgument

        public static void WriteLine(bool value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(value));
        }

        public static void WriteLine(char value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(value));
        }

        public static void WriteLine(char[] buffer, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(buffer));
        }

        public static void WriteLine(char[] buffer, int index, int count, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(buffer, index, count));
        }

        public static void WriteLine(decimal value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(value));
        }

        public static void WriteLine(double value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(value));
        }

        public static void WriteLine(float value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(value));
        }

        public static void WriteLine(int value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(value));
        }

        public static void WriteLine(uint value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(value));
        }

        public static void WriteLine(long value, ConsoleColorArgument colorArgument = null)
        {
            Console.WriteLine(value);
        }

        public static void WriteLine(ulong value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(value));
        }

        public static void WriteLine(object value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(value));
        }

        public static void WriteLine(string value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(value));
        }

        public static void WriteLine(string format, object arg0, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(format, arg0));
        }

        public static void WriteLine(string format, object arg0, object arg1, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(format, arg0, arg1));
        }

        public static void WriteLine(string format, object arg0, object arg1, object arg2,
            ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(format, arg0, arg1, arg2));
        }

        public static void WriteLine(string format, ConsoleColorArgument colorArgument = null, params object[] arg)
        {
            if (arg == null) // avoid ArgumentNullException from string.Format 
                ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(format, null, null));
            // faster than Console.WriteLine(format, (object)arg);
            else
                ColoredConsoleWrapper.Write(colorArgument, () => Console.WriteLine(format, arg));
        }

        public static void Write(string format, object arg0, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(format, arg0));
        }

        public static void Write(string format, object arg0, object arg1, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(format, arg0, arg1));
        }

        public static void Write(string format, object arg0, object arg1, object arg2,
            ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(format, arg0, arg1, arg2));
        }

        public static void Write(string format, object arg0, object arg1, object arg2, object arg3,
            ConsoleColorArgument colorArgument = null, __arglist)
        {
            object[] objArgs;
            int argCount;

            var args = new ArgIterator(__arglist);

            //+4 to account for the 4 hard-coded arguments at the beginning of the list. 
            argCount = args.GetRemainingCount() + 4;

            objArgs = new object[argCount];

            //Handle the hard-coded arguments
            objArgs[0] = arg0;
            objArgs[1] = arg1;
            objArgs[2] = arg2;
            objArgs[3] = arg3;

            //Walk all of the args in the variable part of the argument list. 
            for (var i = 4; i < argCount; i++)
            {
                objArgs[i] = TypedReference.ToObject(args.GetNextArg());
            }

            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(format, objArgs));
        }

        public static void Write(string format, ConsoleColorArgument colorArgument = null, params object[] arg)
        {
            if (arg == null) // avoid ArgumentNullException from string.Format
                ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(format, null, null));
            // faster than Console.Write(format, (object)arg); 
            else
                ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(format, arg));
        }

        public static void Write(bool value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        public static void Write(char value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        public static void Write(char[] buffer, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(buffer));
        }

        public static void Write(char[] buffer, int index, int count, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(buffer, index, count));
        }

        public static void Write(double value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        public static void Write(decimal value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        public static void Write(float value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        public static void Write(int value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        public static void Write(uint value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        public static void Write(long value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        public static void Write(ulong value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        public static void Write(object value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        public static void Write(string value, ConsoleColorArgument colorArgument = null)
        {
            ColoredConsoleWrapper.Write(colorArgument, () => Console.Write(value));
        }

        #endregion
    }
}