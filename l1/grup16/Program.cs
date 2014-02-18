using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup16
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = 5;
            doStuff(b);
            Console.WriteLine(b);
            doStuff(ref b);
            Console.WriteLine(b);
            /*doStuff(out b);
            Console.WriteLine(b);*/

            Console.ReadLine();
        }

        //Bemærk: Man kan ikke overloade metoder hvor forskellen kun ligger i ref eller out
        //Udkommenter derfor én ad gangen for at observere opførsel
        public static void doStuff(int a)
        {
            a *= 2;
        }

        public static void doStuff(ref int a)
        {
            a *= 2;
        }

        /*public static void doStuff(out int a)
        {
            a = 2;
        }*/

    }
}
