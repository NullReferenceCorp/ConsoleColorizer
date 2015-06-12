using System;

namespace HelloWorld
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class ColorizerAttribute : Attribute
    {

   

        public ConsoleColor ForegroundColor { get;  set; }
        public ConsoleColor BackgroundColor { get; set; }

    }
}