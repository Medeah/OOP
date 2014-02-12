using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("intast tal:");
            string inp = Console.ReadLine();
            //dou
            try
            {
                double con = double.Parse(inp);
                Console.WriteLine(System.Math.Sqrt(con));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("wow fejl");
            }
            finally
            {
                Console.WriteLine("alltid");
            }
            
            
            Console.ReadLine();
            
        }
    }
}
