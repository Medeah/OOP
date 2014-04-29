using System;
using System.Collections.Generic;

namespace l12
{
    class Program
    {
        static void Main()
        {
            var x = new EmpployeeList
            {
                new LowIncomeEmployee("Alice"),
                new MiddleIncomeEmployee("Bob"),
                new HighIncomeEmployee("Charlie")
            };
            var tax = new TaxMan();
            var san = new SantaClaus();
            x.Accept(tax);
            foreach (var em in x)
            {
                Console.WriteLine(em.Income);
            }
            x.Accept(san);
            Console.ReadLine();
        }
    }

    interface IVisitor
    {
        void Visit(LowIncomeEmployee employee);
        void Visit(MiddleIncomeEmployee employee);
        void Visit(HighIncomeEmployee employee);
    }

    class TaxMan : IVisitor
    {

        public void Visit(LowIncomeEmployee employee)
        {
            employee.DeductTax(40);
        }

        public void Visit(MiddleIncomeEmployee employee)
        {
            employee.DeductTax(50);
        }

        public void Visit(HighIncomeEmployee employee)
        {
            employee.DeductTax(60);
        }
    }

    class SantaClaus : IVisitor
    {

        public void Visit(LowIncomeEmployee employee)
        {
            employee.ScubaDiving();
        }

        public void Visit(MiddleIncomeEmployee employee)
        {
            employee.TripToLalandia();
        }

        public void Visit(HighIncomeEmployee employee)
        {
            employee.TryFerrari();
        }
    }

    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    class EmpployeeList : IElement , IEnumerable<Employee>
    {
        private readonly List<Employee> _data = new List<Employee>();

        public void Add(Employee em)
        {
            _data.Add(em);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var employee in _data)
            {
                employee.Accept(visitor);
            }
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            foreach (var employee in _data)
            {
                yield return employee;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    abstract class Employee : IElement
    {
        public string Name { get; set; }
        public double Income { get; set; }

        protected Employee(string name, double income)
        {
            Name = name;
            Income = income;
        }
        public virtual void DeductTax(double percent)
        {
            Income -= Income * (percent / 100);
        }

        public abstract void Accept(IVisitor visitor);
    }
    class LowIncomeEmployee : Employee
    {
        public LowIncomeEmployee(string name)
            : base(name, 20000)
        {
            
        }
        public void ScubaDiving()
        {
            Console.WriteLine("Going scuba diving");
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    class MiddleIncomeEmployee : Employee
    {
        public MiddleIncomeEmployee(string name)
            : base(name, 50000)
        {
            
        }
        public void TripToLalandia()
        {
            Console.WriteLine("Taking a trip to Lalandia");
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    class HighIncomeEmployee : Employee
    {
        public HighIncomeEmployee(string name)
            : base(name, 100000)
        {
            
        }
        public void TryFerrari()
        {
            Console.WriteLine("Test driving a ferrari");
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
