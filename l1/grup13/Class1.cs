using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup13
{
    public class Class1
    {
        public static bool IsSorted<T>(IEnumerable<T> list)
        {
            return Enumerable.SequenceEqual(list.OrderBy(x => x), list);
        }
    }
}
