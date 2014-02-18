using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup4
{
    class Program
    {
        static void Main(string[] args)
        {
            for(var i = 1; i <= 5; i++)
            {
                var j = i;
                while (j-- != 0)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                
            }
            Console.ReadLine();
        }
        
    }
}
