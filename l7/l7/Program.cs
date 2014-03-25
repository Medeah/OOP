using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l7
{
    class Program
    {
        static void Main(string[] args)
        {
            var goog = new Stock("Google");
            
            var mig = new Person();
            goog.OnNewHigh += mig.Handler;
            goog.OnNewLow += mig.Handler;
            goog.Value = 100;
            goog.Value = 105;
            goog.Value = 100;
            goog.Value = 1166;

            var aapl = new Stock("Apple");
            var hmm = new StockWatch(aapl, (p, v) => v - p > 5);
            hmm.OnBigChange += mig.Handler;
            aapl.Value = 130;
            aapl.Value = 131;
            aapl.Value = 136;
            aapl.Value = 142;
            aapl.Value = 541;
            Console.ReadLine();
        }
    }
}
