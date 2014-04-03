using System;
using System.Collections.Generic;
using System.Text;

namespace l8
{
    public class Car : IComparable<Car>
    {
        public string Make { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("zero-weight cars disallow for now :)");
                }
                _weight = value;
            }
        }
        public decimal Price { get; set; }
        public Car(string make, int year, int horsePower, double weight, decimal price)
        {
            Make = make;
            Year = year;
            HorsePower = horsePower;
            Weight = weight;
            Price = price;
        }

        //http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.name.aspx
        private static readonly System.Globalization.CultureInfo DanskKultur =
        new System.Globalization.CultureInfo("da-dk");
        public override string ToString()
        {
            const string separator = ", ";
            var sb = new StringBuilder();
            sb.Append(Make).Append(separator)
            .Append(Year).Append(separator)
            .Append(HorsePower).Append(" HP").Append(separator)
            .Append(Weight).Append(" Kg").Append(separator)
            .Append(String.Format(DanskKultur, "{0:C} kr.", Price));
            return sb.ToString();
        }

        public int CompareTo(Car other)
        {
            int result;
            if (ReferenceEquals(this, other))
            {
                result = 0;
            }
            else
            {
                if (other == null)
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

            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Car left, Car right)
        {
            if (left == null)
            {
                return true;
            }

            return left.CompareTo(right) > 0;
        }

        public class PowerToWeightRatioComparer : IComparer<Car>
        {
            public int Compare(Car x, Car y)
            {
                if (ReferenceEquals(x, y))
                {
                    return 0;
                }
                if (x == null)
                {
                    return 1;
                }
                if (y == null)
                {
                    return -1;
                }
                var xPowerToWeight = x.HorsePower / x.Weight;
                var yPowerToWeight = y.HorsePower / y.Weight;
                return xPowerToWeight.CompareTo(yPowerToWeight);
            }
        }
 
    }
}
