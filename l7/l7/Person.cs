using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l7
{
    class Person
    {
        public void Handler(object sender, Stock.StockArgs args)
        {
            Console.WriteLine("Nu har værdien ændret sig til: " + args.Value);
        }
    }
}
