using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup9
{
    class Program
    {
        static void Main(string[] args)
        {
            var folk = new List<string>();
            folk.Add("Simon");
            folk.Add("Alex");
            folk.Add("Kasper");
            folk.Insert(2, "Mikkle");
            folk.Add("Frederik");
            folk.Add("Frederik");


            folk.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            folk.Remove("Frederik");
            folk.ForEach(x => Console.WriteLine(x));

            Console.ReadLine();
        }
    }
}
