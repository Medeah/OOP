using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup11
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "The quick brown fox jumps over the lazy dog";
            
            Console.WriteLine(s.Replace(' ', '_'));

            var list = s.Split(' ');
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
