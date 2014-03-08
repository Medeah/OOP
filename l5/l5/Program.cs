using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l5
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCovariance();
            TestContravariance();
            Console.ReadLine();
        }

        public static void DequeueAndPrint<T>(MyQueue<T> q)
        {
            while (!q.IsEmpty)
            {
                Console.WriteLine("Head = {0}", q.Head);
                Console.WriteLine("Tail = {0}", q.Tail);
                Console.WriteLine("Vi fjerner {0}", q.Dequeue());
            }
        }

        public static void TestCovariance()
        {
            MyQueue<Car> cars = new MyQueue<Car>(10);
            cars.Enqueue(new Car() { Make = "Opel", Model = "Zafira" });
            cars.Enqueue(new Car() { Make = "Opel", Model = "Kadett" });
            cars.Enqueue(new Car() { Make = "Mazda", Model = "6" });
            MyQueue<Bus> busses = new MyQueue<Bus>(10);
            busses.Enqueue(new Bus() { Make = "Ford", Model = "Buzzy" });
            busses.Enqueue(new Bus() { Make = "Scania", Model = "SlowMover" });
            DequeueAndPrintVehicles(cars);
            DequeueAndPrintVehicles(busses);
        }

        public static void DequeueAndPrintVehicles<T>(MyQueue<T> vehicles)
            where T : Vehicle
        {
            Vehicle v;
            while (!vehicles.IsEmpty)
            {
                v = vehicles.Dequeue();
                Console.WriteLine("{0} {1}", v.Make, v.Model);
            }
        }

        public static void TestContravariance()
        {
            //Bemærk: Studs forventer en MyComparer<Student>, men får en MyComparer<Person>
            //Det kan kun lade sig gøre hvis contravarians er muliggjort
            var studs = new MyFlexibleOrderedQueue<Student>(10, new WeightComparer());
            studs.Enqueue(new Student() { Name = "Ib", Weight = 90 });
            studs.Enqueue(new Student() { Name = "Lis", Weight = 58 });
            studs.Enqueue(new Student() { Name = "Bo", Weight = 75 });
            studs.Enqueue(new Student() { Name = "Pia", Weight = 65 });
            DequeueAndPrint<Student>(studs);
        }
    }
}
