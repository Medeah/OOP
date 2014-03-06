using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l5
{
    class QueueException : Exception
    {
        public QueueException() : base() { }
        public QueueException(string s) : base(s) { }
        public QueueException(string s, Exception ex) : base(s, ex) { }
    }

    class QueueFullException : QueueException
    {
        public QueueFullException() : base() {}
        public QueueFullException(string s) : base(s) {}
        public QueueFullException(string s, Exception ex) : base(s, ex) {}
    }

    class MyQueue<T>
    {
        protected T[] data;
        protected int head = 0; // foreste plads i køen
        protected int end = 0; // første tomme plads bagers i køen
        protected int elems = 0;
        public T Head {
            get {
                if (elems == 0)
                {
                    throw new QueueException("Der er ikke plads til flere");
                }
                return data[head];
            }
            set {
                data[head] = value;
            }
        }
        public T Tail {
            get {
                if (elems == 0)
                {
                    throw new QueueFullException("Der er ikke plads til flere");
                }
                int index = end == 0 ? data.Length - 1 : end - 1;
                return data[index];
            } set {
                int index = end == 0 ? data.Length - 1 : end - 1;
                data[index] = value;
            }
        }

        public bool IsEmpty {
            get {
                return elems == 0;
            }
        }
        public bool IsFull {
            get
            {
                return elems == data.Length;
            }
        }


        public MyQueue(int size)
        {
            data = new T[size];
        }

        public virtual void Enqueue(T item)
        {
            if (this.IsFull)
            {
                throw new QueueFullException("Der er ikke plads til flere");
            }
            data[end] = item;
            end = (end + 1) % data.Length;
            elems++;
        }
        public T Dequeue()
        {
            if(this.IsEmpty)
            {
                throw new QueueException("Der er ikke flere elementer tilbage");
            }
            int index = head;
            head = (head + 1) % data.Length;
            elems--;
            return data[index];
        }

        
        
    }

    class MyOrderedQueue<U> : MyQueue<U>
        where U : IComparable<U>
    {
        public MyOrderedQueue(int size) : base(size) { }

        public override void Enqueue(U item)
        {
            if (this.IsFull)
            {
                throw new QueueFullException("Der er ikke plads til flere");
            }

            int i = head;
            while (i != end && (item.CompareTo(this.data[i]) > 0))
            {
                i = (i + 1) % this.data.Length;
            }


            for (int j = end; j != i; j = j == 0 ? this.data.Length - 1 : j - 1)
            {
                int index = j == 0 ? this.data.Length - 1 : j - 1;
                this.data[j] = this.data[index];
            }

            this.data[i] = item;
            end = (end + 1) % data.Length;
            elems++;
        }
    }

    class Person : IComparable<Person>
    {
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }
        public int CompareTo(Person other)
        {
            return this.Age - other.Age;
        }
    }

    class Student : Person
    {

    }

    class MyFlexibleOrderedQueue<T> : MyQueue<T>
    {
        private MyComparer<T> comparer;
        public MyFlexibleOrderedQueue(int size, MyComparer<T> com) : base(size)
        {
            this.comparer = com;
        }

        public override void Enqueue(T item)
        {
            if (this.IsFull)
            {
                throw new QueueFullException("Der er ikke plads til flere");
            }

            int i = head;
            
            while (i != end && (comparer.Compare(item, data[i]) > 0))
            {
                i = (i + 1) % this.data.Length;
            }


            for (int j = end; j != i; j = j == 0 ? this.data.Length - 1 : j - 1)
            {
                int index = j == 0 ? this.data.Length - 1 : j - 1;
                this.data[j] = this.data[index];
            }

            this.data[i] = item;
            end = (end + 1) % data.Length;
            elems++;
        }
    }

    abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
    }
    abstract class MotorVehicle : Vehicle { }
    class Car : MotorVehicle { }
    class Bus : MotorVehicle { }




    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> kø = new MyQueue<int>(4);
            kø.Enqueue(1);
            kø.Enqueue(2);
            kø.Enqueue(3);
            kø.Enqueue(4);

            DequeueAndPrint(kø);

            MyOrderedQueue<int> sort = new MyOrderedQueue<int>(3);

            sort.Enqueue(20);
            for (int i = 0; i < 10; i++)
            {
                sort.Enqueue(3);
                sort.Enqueue(6);
                Console.WriteLine(sort.Dequeue());
                Console.WriteLine(sort.Dequeue());
            }

            sort.Enqueue(3);
            sort.Enqueue(6);
            DequeueAndPrint(sort);


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

    interface MyComparer<in T>
    {
        int Compare(T x, T y);
    }

    class WeightComparer : MyComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Weight.CompareTo(y.Weight);
        }
    }
  
}
