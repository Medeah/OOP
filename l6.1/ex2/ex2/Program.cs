using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{

    enum Fuel { Diesel, Octane92, Octane95 }

    abstract class MotorVehicle
    {
        protected Fuel _fuel;

        public string Make { get; set; } //VW, Audi, Skoda...
        public string Model { get; set; } //Golf, Polo, A3, Fabia, etc.
        public int Year { get; set; }
        public decimal Price { get; set; }

        public virtual Fuel Fuel
        {
            get { return _fuel; }
            set { _fuel = value; }
        }
    }

    class Bus : MotorVehicle
    {
        public Bus()
        {
            _fuel = Fuel.Diesel;
        }

        public int NumSeats { get; set; }

        public override Fuel Fuel
        {
            set { } //do nothing - only diesel is allowed
        }
    }

    class Car : MotorVehicle
    {
        public bool HasSunRoof { get; set; }
    }

    class QueryVehiclesExercise
    {
        public static void TestVehicles()
        {
            /*List<int> n = new List<int>();
            n.OrderBy(n1 => n1);
            foreach (int n2 in n)
                Console.WriteLine(n2);*/


            List<MotorVehicle> vehicles = new List<MotorVehicle>()
            {
                new Car() { Make = "Volvo",  Model = "Amazon", Year = 1970, Fuel = Fuel.Octane95, Price = 112000 },
                new Car() { Make = "VW",     Model = "Polo",   Year = 1982, Fuel = Fuel.Octane95, Price = 112000 },
                new Car() { Make = "Opel",   Model = "Zafira", Year = 2002, Fuel = Fuel.Octane95, Price = 112000 },
                new Car() { Make = "Ford",   Model = "Fiesta", Year = 1994, Fuel = Fuel.Octane92, HasSunRoof = true, Price = 72000 },
                new Car() { Make = "Mazda",  Model = "6",      Year = 2007, Fuel = Fuel.Octane95, Price = 200000 },
                new Car() { Make = "Opel",   Model = "Astra",  Year = 1995, Fuel = Fuel.Octane92, HasSunRoof = true, Price = 45000 },
                new Car() { Make = "Opel",   Model = "Astra",  Year = 1997, Fuel = Fuel.Diesel, Price = 52000 },
                new Car() { Make = "Opel",   Model = "Zafira", Year = 2001, Fuel = Fuel.Diesel, Price = 137000 },
                new Car() { Make = "Ford",   Model = "Focus",  Year = 2007, Fuel = Fuel.Octane92, HasSunRoof = true, Price = 199999 },
                new Car() { Make = "Opel",   Model = "Astra",  Year = 1996, Fuel = Fuel.Diesel, Price = 29000 },
                new Bus() { Make = "Scania", Model = "Buzz",   Year = 1999, Price = 275000, NumSeats = 52},
                new Bus() { Make = "Scania", Model = "Fuzz",   Year = 2000, Price = 225000, NumSeats = 12}
            };


            //ex 1
            Console.WriteLine(vehicles.Average(x => x.Price));

            //ex 2
            Console.WriteLine(vehicles.Where(x => x is Bus).Select(v => v as Bus).Average(b => b.NumSeats));

            //ex 3
            Console.WriteLine(vehicles.OfType<Car>().Where(c => c.HasSunRoof).Count());

            //ex 4
            foreach (var list in vehicles.GroupBy(x => x.Make))
            {
                Console.WriteLine("----------");
                foreach (var vir in list)
                {
                    Console.WriteLine(vir.Make);
                }
            }

            Console.WriteLine("\nex5:");

            int MIN = 10000;
            int MAX = 400000;

            // ex 5
            foreach (var vir in vehicles
                .Where(v => v.Fuel == Fuel.Octane92 || v.Fuel == Fuel.Octane95)
                .Where(x => MIN < x.Price && x.Price < MAX)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .ThenBy(x => x.Price))
            {
                Console.WriteLine(vir.Model);
            }

            Console.WriteLine("\nex6:");

            int nu = DateTime.Now.Year;

            foreach (var vir in vehicles
                .Where(x => (nu - x.Year) >= 25)
                .Select(x => new { Model_Make = x.Make + " " + x.Model, YearsOld = nu - x.Year }))
            {
                Console.WriteLine(vir.Model_Make + ", Alder: " + vir.YearsOld);
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            QueryVehiclesExercise.TestVehicles();
            Console.ReadLine();
        }
    }
}
