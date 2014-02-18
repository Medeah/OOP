using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grup7
{
    class Program
    {
        public enum PlayState { Play = 3, Stop, Pause, Record };
        static void Main(string[] args)
        {

            PlayState p = PlayState.Stop;
            Console.WriteLine(p);
            Console.ReadLine();
            
        }
    }
}
