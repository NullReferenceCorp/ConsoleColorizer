using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NRC.ConsoleColorizer;
 namespace HelloWorld
{
    class Program
    {
        
        public static  dynamic Console { get; set; }=new ConsoleColorizer();
        
      
        static void Main(string[] args)
        {
            Console.WriteLine( "Hey there, I am the default.");
            Console.WriteLine(new ConsoleColorArgument(ConsoleColor.Blue,null), "HI BLUE");

            
        }

      
    }
}
