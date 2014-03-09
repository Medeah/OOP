using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l5
{
    public class Person : IComparable<Person>
    {
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }
        public int CompareTo(Person other)
        {
            return this.Age - other.Age;
        }
    }
}
