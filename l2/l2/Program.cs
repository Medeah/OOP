using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2
{
    class Pet
    {
        public string Name { get; set; }
        public Pet(string name)
        {
            Name = name;
        }
    }

    public enum Gender { Male, Female }
    class Person
    {

        public Person(string name, DateTime birthday)
            : this(name, birthday, Gender.Female)
        { }

        public Person(string name, DateTime birthday, Gender gender)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Gender = gender;
            this.Id = Person.NextId++;
        }


        

        private string _name;

        public string Name
        {
            get { return _name; }
            set { if (!String.IsNullOrEmpty(value)) _name = value; }
        }


        readonly public DateTime Birthday;

        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set
            {
                if (0 <= value && value <= 300)
                {
                    _weight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
                
            }
        }

        private double _height;

        public double Height
        {
            get { return _height; }
            set 
            {
                if (value < 1.2)
                {
                    _height = 1.2;
                }
                else if (value > 3.0)
                {
                    _height = 3.0;
                } else {
                    _height = value;
                }
                
            }
        }

        public double BMI()
        {
            return Weight / (Height * Height);
        }

        public int Age {
            get
            {
                return DateTime.Today.Year - Birthday.Year; //TODO
            }
        }


        public Gender Gender { get; set; }

        internal bool Married { get; set; }

        public static string Title(Person p)
        {
            if (p.Gender == Gender.Male)
            {
                return "Mr.";
            }
            else if (p.Married)
            {
                return "Mrs.";
            }
            else
            {
                return "Ms.";
            }
        }
        static private int _NextId = 1;

        static public int NextId
        {
            get { return _NextId; }
            private set { _NextId = value; }
        }
        
        public int Id { get; private set; }

        private Person _partner;

        public Person Partner
        {
            get { return _partner; }
            set {
                this.Married = !(value == null);
                _partner = value;
            }
        }

        private List<Pet> _pets = new List<Pet>();

        public List<Pet> Pets
        {
            get { return _pets; }
        }

        public void AddPet(Pet p)
        {
            _pets.Add(p);
        }

        public void RemovePet(Pet p)
        {
            _pets.Remove(p);
        }
        
        
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mig = new Person("Frederik", DateTime.Parse("1990-10-31T07:34:42-5:00"), Gender.Male);
            mig.Height = 1.90;
            mig.Weight = 88;
            mig.Name = "";

            Console.WriteLine(mig.Name);

            Console.WriteLine(mig.BMI());
            Console.WriteLine(mig.Age);
            Console.WriteLine(Person.Title(mig));

            var marie = new Person("Marie", DateTime.Parse("1991-4-20T07:34:42-5:00"));

            Console.WriteLine(mig.Id);
            Console.WriteLine(marie.Id);

            // bryllup
            marie.Partner = mig;
            mig.Partner = marie;
            // halv skilsmisse
            mig.Partner = null;

            Console.WriteLine(mig.Married);
            Console.WriteLine(marie.Married);

            var kat = new Pet("miv");
            var hund = new Pet("rollo");

            marie.AddPet(kat);
            marie.AddPet(hund);

            foreach (var pet in marie.Pets)
            {
                Console.WriteLine(pet.Name);
            }

            Console.ReadLine();
        }
    }
}
