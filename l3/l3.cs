using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace l3
{


    public enum Gender { Male, Female }
    class Person
    {
        public Person() {}

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

        public override string ToString() {
            return base.ToString() + String.Format(": {0} {1}", Person.Title(this), Name);
        }

        public void PetTalk() {
            foreach (var pet in Pets) {
                pet.Talk();
            }
        }

        public int NumberOfDogs() {
            return Pets.Where(x => x is Dog).Count();
        }

        public double AverageMiawFactor() {
            return Pets
                    .Where(p => p is Cat)
                    .Select(p => p as Cat)
                    .Average(c => c.MiawFactor);
        }
        
        public void WalkThePets() {
            foreach (var pet in Pets) {
                pet.Walk();
            }
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

        private bool _updatingPartner;
        private Person _partner;

        public Person Partner
        {
            get { return _partner; }
            set
            {
                this.Married = !(value == null);

                if (!(_updatingPartner || value == _partner)) {
                     _updatingPartner = true;

                    Person oldPartner = _partner;
                    if (oldPartner != null) {
                        oldPartner.Partner = null;
                    }

                    _partner = value;
                    if (_partner != null) {
                        _partner.Partner = this;
                    }

                    _updatingPartner = false;
                }
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

    abstract class Pet
    {
        public string Name { get; set; }

        public virtual void Walk() {
            Console.WriteLine("Swoosh Swoosh");
        }

        public abstract void Talk();
    }

    abstract class Cat : Pet {

        protected int _miawFactor;

        public int MiawFactor {
            get { return _miawFactor; }
            set { 
                if ((1 <= value) && (value <= 10)) {
                    _miawFactor = value; 
                } else {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    class Savannah : Cat {

        public Savannah() {
            _miawFactor = 11;
        }
        public override void Talk() {
            Console.WriteLine("Savannah talking");
        }

    }

    class Persian : Cat {
        public Persian() {
            _miawFactor = 7;
        }
        
        public override void Talk() {
            Console.WriteLine("Persian talking");
        }
    }

    abstract class Dog : Pet {
        public override void Talk() {
            Console.WriteLine("Wuf");
        }
    }

    class Beagle : Dog {
        public sealed override void Talk() {
            base.Talk();
            Console.WriteLine("Beagle");
        }
    }

    class Greyhound : Dog {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new Beagle();
            test.Talk();


            var mig = new Person("Frederik", DateTime.Parse("1990-10-31T07:34:42-5:00"), Gender.Male);

            var marie = new Person("Marie", DateTime.Parse("1991-4-20T07:34:42-5:00"));

            // bryllup
            marie.Partner = mig;
            Console.WriteLine(mig.Married);
            Console.WriteLine(marie.Married);
            
            // Skilsmisse
            mig.Partner = null;
            Console.WriteLine(mig.Married);
            Console.WriteLine(marie.Married);

            Console.WriteLine(mig);

            mig.AddPet(new Persian());
            mig.AddPet(new Persian());
            mig.AddPet(new Savannah());
            mig.AddPet(new Beagle());
            mig.AddPet(new Greyhound());
            mig.WalkThePets();
            mig.PetTalk();
            Console.WriteLine(mig.NumberOfDogs());
            Console.WriteLine(mig.AverageMiawFactor());
        }
    }
}
