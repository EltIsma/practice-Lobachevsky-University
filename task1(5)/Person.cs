using System;

namespace PersonNS
{
    public class Person
    {
         private int age;
          private static List<Person> people = new List<Person>();
        public string Name { get; set; }
         public int Age
        {
            get { return age; }
            set { if (value < 0) value = 0; age = value; }
        }

        public static List<Person> People
        { 
            get { return people; }
            set { people = value; }
        }


        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

         public Person(Person other)
        {
            Name = other.Name;
            Age = other.Age;
        }

        public virtual void Print()
        {
            Console.WriteLine($"{GetType().Name}: {Name}, {Age} лет");
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}, {Age} лет";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Person other = (Person)obj;
            return Name == other.Name && Age == other.Age;
        }

        public override int GetHashCode()
        {
            return (Name + Age).GetHashCode();
        }

          public virtual object Clone()
        {
            return new Person(Name, Age);
        }

        public static Person RandomPerson()
        {
            List<Person> pn = People.OfType<Person>().ToList();

            if (pn.Count == 0) return null;

            Random random = new Random();
            int randomIndex = random.Next(0, pn.Count);

            return pn[randomIndex];
        }
    }
}