using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv dit fornavn: ");
            var first = Console.ReadLine();
            Console.Write("Skriv dit efternavn: ");
            var last = Console.ReadLine();
            Console.WriteLine(first + " " + last);
            Console.ReadLine();
        }
    }
}
