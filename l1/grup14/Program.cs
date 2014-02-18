using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(1, 2, 3, 4));
            Console.ReadLine();
        }

        static double Sum(double x1, double x2)
        {
            return x1 + x2;
        }

        static double Sum(double x1, double x2, double x3)
        {
            return x1 + x2 + x3;
        }

        static double Sum(params double[] numbers)
        {
            return numbers.Aggregate((x, y) => x + y);
        }
    }
}
