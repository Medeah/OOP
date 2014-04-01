using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l8
{
    class Program
    {
        static void testCar()
        {
            //Collection initializer fordi vi har Add() metode
            SortedList<int> msl = new SortedList<int>()
                {
                    5, 2, 9, 8, 10, 3, 4
                };
            msl.Add(7);

            //Operator overloading
            msl = msl + 1;
            msl += 6;

            //Her bruges indexeren:
            for (int i = 0; i < msl.Count; i++)
                Console.WriteLine("Element på plads nr. {0} er {1}", i, msl[i]);

            //De tre iteratorer:
            Console.WriteLine("Forward order:");
            foreach (int i in msl)
                Console.WriteLine(i);
            Console.WriteLine("Reverse order:");
            foreach (int i in msl.GetElementsReversed())
                Console.WriteLine(i);
            Console.WriteLine("Even elements, forward order:");
            foreach (int i in msl.GetElements(x => x % 2 == 0))
                Console.WriteLine(i);
            msl.Remove(6);

            //Mere operator overloading
            msl = msl - 9;
            msl -= 2;
            Console.WriteLine("MySortedList after removal:");
            foreach (int i in msl)
                Console.WriteLine(i);

            //Test om det virker med biler (IComparable og IComparer)
            SortedList<Car> mySortedCars = new SortedList<Car>()
            {
                new Car("Mazda 6", 2005, 110, 950, 264999.95M),
                new Car("Mazda 3", 2007, 90, 700, 185000),
                new Car("Mazda 0", 2014, 130, 0, 20000M),
                new Car("VW Golf 6", 2009, 150, 1050, 285000),
                new Car("Bugatti Veyron", 2008, 1001, 1000, 22265000),
                new Car("Renault Twingo", 2011, 55, 700, 85000),
                new Car("VW Polo BlueMotion", 2011, 90, 800, 195000),
                new Car("Ford Mondeo", 207, 150, 1105, 365000)
            };
            mySortedCars += new Car("Mazda 3", 2006, 90, 798, 165000);

            //forudsætter implementation af IComparable
            foreach (Car c in mySortedCars)
                Console.WriteLine(c);
            List<Car> myUnsortedCars = new List<Car>(mySortedCars);
            Console.WriteLine("Cars sorted according to their power-to-weight ratio:");

            //forudsætter implementation af IComparer
            myUnsortedCars.Sort(new Car.PowerToWeightRatioComparer());
            foreach (Car c in myUnsortedCars)
                Console.WriteLine(c);
        }

        static void Main(string[] args)
        {
            var test = new SortedList<int>();
            test.Add(3);
            test.Add(2);
            test.Add(8);
            test.Add(1);
            test.Add(2);
            test.Add(9);
            test.Add(7);
            test = test + 12;
            test += 13;
            test = test - 8;
            test -= 13;
            
            test.Add(47);

            foreach (var item in test)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(test[0]);

            testCar();
            Console.ReadLine();
        }
    }
}
