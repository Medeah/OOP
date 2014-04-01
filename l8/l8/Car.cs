using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l8
{
    public class Car : IComparable<Car>
    {
        public string Make { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        private double weight;
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("zero-weight cars disallow for now :)");
                }
                weight = value;
            }
        }
        public decimal Price { get; set; }
        public Car(string make, int year, int horsePower, double weight, decimal price)
        {
            this.Make = make;
            this.Year = year;
            this.HorsePower = horsePower;
            this.Weight = weight;
            this.Price = price;
        }

        //http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.name.aspx
        private static System.Globalization.CultureInfo _danskKultur =
        new System.Globalization.CultureInfo("da-dk");
        public override string ToString()
        {
            string separator = ", ";
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Make).Append(separator)
            .Append(this.Year).Append(separator)
            .Append(this.HorsePower).Append(" HP").Append(separator)
            .Append(this.Weight).Append(" Kg").Append(separator)
            .Append(String.Format(_danskKultur, "{0:C} kr.", this.Price));
            return sb.ToString();
        }

        public int CompareTo(Car other)
        {
            int result;
            if (Car.ReferenceEquals(this, other))
            {
                result = 0;
            }
            else
            {
                if (this == null)
                {
                    result = 1;
                }           
                else if (other == null)
                {
                    result = -1;
                }
                else
                {
                    result = other.Price.CompareTo(other.Price);
                }
            }
            return result;
        }

        public static bool operator <(Car left, Car right)
        {
            if (left == null)
            {
                return false;
            }

            else
            {
                return left.CompareTo(right) < 0;
            }   
        }

        public static bool operator >(Car left, Car right)
        {
            if (left == null)
            {
                return true;
            }

            else
            {
                return left.CompareTo(right) > 0;
            }
        }

        public class PowerToWeightRatioComparer : IComparer<Car>
        {
            public int Compare(Car x, Car y)
            {
                if (Car.ReferenceEquals(x, y))
                {
                    return 0;
                }
                else
                {
                    if (x == null)
                    {
                        return 1;
                    }
                    else if (y == null)
                    {
                        return -1;
                    }
                    else
                    {
                        var xPowerToWeight = x.HorsePower / x.Weight;
                        var yPowerToWeight = y.HorsePower / y.Weight;
                        return xPowerToWeight.CompareTo(yPowerToWeight);
                    }
                }
            }
        }
 
    }
}
