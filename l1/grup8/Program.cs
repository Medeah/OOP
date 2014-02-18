using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lottery = new int[7];
            Random r = new Random();
            for(int i = 0; i < 7; i++)
            {
                lottery[i] = r.Next(1, 37);
            }
           
            foreach(var i in lottery)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
            
        }
    }
}
