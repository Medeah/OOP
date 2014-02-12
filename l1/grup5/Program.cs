using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup5
{
    class Program
    {
        static void Main(string[] args)
        {
            var tal = 300;
            Console.WriteLine("Hex: {0:X}", tal);

            decimal d = 678.5M;
            Console.WriteLine(d);

            ulong i = 9990000000000000000;
            Console.WriteLine(i);

            double d2 = 9.99e18;
            Console.WriteLine(d2);
            Console.ReadLine();

        }
    }
}
