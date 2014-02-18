using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(M(false)); 
            Console.WriteLine(M(0));    
            Console.WriteLine(M(3.0, 4));
            Console.WriteLine(M(3, 4));  
            Console.WriteLine(M(3, 4.0));

            Console.WriteLine(M((byte)3, (byte)4));

            Console.WriteLine(M(y: 4, x: 3));
            Console.ReadLine();

            
        }

        public static double M(int i) { return -i; }
        public static bool M(bool b) { return !b; }
        public static double M(byte x, byte y) { return x + y; }
        public static double M(int x, int y) { return 2 * (x + y); }
        public static double M(int x, double y) { return 3 * (x + y); }
        public static double M(double x, double y) { return 4 * (x + y); }
    }
}
