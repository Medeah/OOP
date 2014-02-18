using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup12
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var res = grup13.Class1.IsSorted(list);
            Console.WriteLine(res);

            int[] array = { 1, 2, 3};
            res = grup13.Class1.IsSorted(array);
            Console.WriteLine(res);

            string[] s_array = { "Hej", "Frederik"};
            res = grup13.Class1.IsSorted(s_array);
            Console.WriteLine(res);
            
            Console.ReadLine();
        }
    }
}
