using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("intast tal:");
            string inp = Console.ReadLine();
            int i;
            if (int.TryParse(inp, out i)) 
            {
                Console.WriteLine(i);
            }
            else
            {
                Console.WriteLine("qq");
            }
            Console.ReadLine();
            

        }
    }
}
