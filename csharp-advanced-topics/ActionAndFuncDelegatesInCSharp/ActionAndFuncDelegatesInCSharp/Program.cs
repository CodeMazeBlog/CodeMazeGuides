using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace ActionAndFuncDelegatesInCSharp
{
    public class Program
    {

        public static List<string> FuncDelegate(List<Person> threePersons)
        {
            Console.WriteLine("Using Func delegate to fully introduce a person");

            Func<Person, string> fullIntroduction = (person) =>
            {
                return $"{person.Name} is a {person.Gender} from {person.Country}";
            };

            List<string> results = new List<string>();  

            foreach (Person person in threePersons)
            {
                Console.WriteLine(fullIntroduction(person));
                results.Add(fullIntroduction(person));
            }

            return results;
        }

        public static List<string> ActionDelegate(List<Person> threePersons)
        {
            Console.WriteLine("Using Action delegate to introduce a person");

            Action<string, string> introduction = (name, gender) =>
            {
                Console.WriteLine($"{name} is a {gender}");
            };

            List<string> results = new List<string>();

            foreach (Person person in threePersons)
            {
                introduction(person.Name, person.Gender);
                results.Add($"{person.Name} is a {person.Gender}");
            }

            return results;
        }

        public static void Main(string[] args)
        {
            List<Person> threePersons = new List<Person>()
            {
                new Person {Name = "Jane", Gender = "Female", Country = "Australia"},
                new Person {Name = "Mark", Gender = "Male", Country = "Germany"},
                new Person {Name = "John", Gender = "Male", Country = "Mexico"},
            };

            ActionDelegate(threePersons);

            FuncDelegate(threePersons);

            Console.ReadKey();
        }
    }
}
