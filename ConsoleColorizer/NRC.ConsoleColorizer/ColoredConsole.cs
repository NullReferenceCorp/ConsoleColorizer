using System;

namespace NRC.ConsoleColorizer
{
    public class ColoredConsole
    {
        public static void WriteLine(bool value)
        {
            Console.WriteLine(value);
        }

        
        public static void WriteLine(char value)
        {
            Console.WriteLine(value);
        }

        
        public static void WriteLine(char[] buffer)
        {
            Console.WriteLine(buffer);
        }

        
        public static void WriteLine(char[] buffer, int index, int count)
        {
            Console.WriteLine(buffer, index, count);
        }

        
        public static void WriteLine(decimal value)
        {
            Console.WriteLine(value);
        }

        
        public static void WriteLine(double value)
        {
            Console.WriteLine(value);
        }

        
        public static void WriteLine(float value)
        {
            Console.WriteLine(value);
        }

        
        public static void WriteLine(int value)
        {
            Console.WriteLine(value);
        }

        
        
        public static void WriteLine(uint value)
        {
            Console.WriteLine(value);
        }

        
        public static void WriteLine(long value)
        {
            Console.WriteLine(value);
        }

        
        
        public static void WriteLine(ulong value)
        {
            Console.WriteLine(value);
        }

        
        public static void WriteLine(Object value)
        {
            Console.WriteLine(value);
        }

        
        public static void WriteLine(String value)
        {
            Console.WriteLine(value);
        }


        
        public static void WriteLine(String format, Object arg0)
        {
            Console.WriteLine(format, arg0);
        }

        
        public static void WriteLine(String format, Object arg0, Object arg1)
        {
            Console.WriteLine(format, arg0, arg1);
        }

        
        public static void WriteLine(String format, Object arg0, Object arg1, Object arg2)
        {
            Console.WriteLine(format, arg0, arg1, arg2);
        }

        [System.Security.SecuritySafeCritical]  // auto-generated
        
        
        public static void WriteLine(String format, Object arg0, Object arg1, Object arg2, Object arg3, __arglist)
        {
            Object[] objArgs;
            int argCount;

            ArgIterator args = new ArgIterator(__arglist);

            //+4 to account for the 4 hard-coded arguments at the beginning of the list. 
            argCount = args.GetRemainingCount() + 4;

            objArgs = new Object[argCount];

            //Handle the hard-coded arguments 
            objArgs[0] = arg0;
            objArgs[1] = arg1;
            objArgs[2] = arg2;
            objArgs[3] = arg3;

            //Walk all of the args in the variable part of the argument list. 
            for (int i = 4; i < argCount; i++)
            {
                objArgs[i] = TypedReference.ToObject(args.GetNextArg());
            }

            Console.WriteLine(format, objArgs);
        }


        
        public static void WriteLine(String format, params Object[] arg)
        {
            if (arg == null)                       // avoid ArgumentNullException from String.Format 
                Console.WriteLine(format, null, null); // faster than Console.WriteLine(format, (Object)arg);
            else
                Console.WriteLine(format, arg);
        }

        
        public static void Write(String format, Object arg0)
        {
            Console.Write(format, arg0);
        }

        
        public static void Write(String format, Object arg0, Object arg1)
        {
            Console.Write(format, arg0, arg1);
        }

        
        public static void Write(String format, Object arg0, Object arg1, Object arg2)
        {
            Console.Write(format, arg0, arg1, arg2);
        }

        [System.Security.SecuritySafeCritical]  // auto-generated 
        
        
        public static void Write(String format, Object arg0, Object arg1, Object arg2, Object arg3, __arglist)
        {
            Object[] objArgs;
            int argCount;

            ArgIterator args = new ArgIterator(__arglist);

            //+4 to account for the 4 hard-coded arguments at the beginning of the list. 
            argCount = args.GetRemainingCount() + 4;

            objArgs = new Object[argCount];

            //Handle the hard-coded arguments
            objArgs[0] = arg0;
            objArgs[1] = arg1;
            objArgs[2] = arg2;
            objArgs[3] = arg3;

            //Walk all of the args in the variable part of the argument list. 
            for (int i = 4; i < argCount; i++)
            {
                objArgs[i] = TypedReference.ToObject(args.GetNextArg());
            }

            Console.Write(format, objArgs);
        }


        
        public static void Write(String format, params Object[] arg)
        {
            if (arg == null)                   // avoid ArgumentNullException from String.Format
                Console.Write(format, null, null); // faster than Console.Write(format, (Object)arg); 
            else
                Console.Write(format, arg);
        }

        
        public static void Write(bool value)
        {
            Console.Write(value);
        }

        
        public static void Write(char value)
        {
            Console.Write(value);
        }

        
        public static void Write(char[] buffer)
        {
            Console.Write(buffer);
        }

        
        public static void Write(char[] buffer, int index, int count)
        {
            Console.Write(buffer, index, count);
        }

        
        public static void Write(double value)
        {
            Console.Write(value);
        }

        
        public static void Write(decimal value)
        {
            Console.Write(value);
        }

        
        public static void Write(float value)
        {
            Console.Write(value);
        }

        
        public static void Write(int value)
        {
            Console.Write(value);
        }

        
        
        public static void Write(uint value)
        {
            Console.Write(value);
        }

        
        public static void Write(long value)
        {
            Console.Write(value);
        }

        
        
        public static void Write(ulong value)
        {
            Console.Write(value);
        }

        
        public static void Write(Object value)
        {
            Console.Write(value);
        }

        
        public static void Write(String value)
        {
            Console.Write(value);
        }

    }
}