using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l5
{
    interface MyComparer<in T>
    {
        int Compare(T x, T y);
    }
}
