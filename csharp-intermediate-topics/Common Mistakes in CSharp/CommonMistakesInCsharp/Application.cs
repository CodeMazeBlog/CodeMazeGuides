using System.Text;
using static CommonMistakesInCsharp.Application;

namespace CommonMistakesInCsharp
{
    public class Application
    {

        public class microwaveoven { } //wrong


        public class MicrowaveOven { } // right

        public interface Machine { } //wrong

        //Right
        public interface IMachine { } //right

        int lv = 3; //wrong
        int no_si = 20; //wrong

        int levels = 3; //right
        int numberOfStudents = 20; //right



        int id = 0; //an exception

        //namespace Api.Services.Implementations.EntityService

        public struct Person
        {
            public string name;
            public int age;
            public string team;
        }

        public class Car
        {
            public int id;
            public string name;
        }

        public static bool MisplaceTypes()
        {
            Person personOne = new();
            Person personTwo = new();

            Console.WriteLine(personOne.Equals(personTwo)); //True

            Car carOne = new();
            Car carTwo = new();

            Console.WriteLine(carOne == carTwo); //False
            return carOne == carTwo;
        }


        public static string OverLookingExtensionTypes()
        {
            Person personOne = new();
            personOne.name = "John";
            return personOne.PersonExtension();
        }

        public static string StringConcantenation()
        {
            string[] words = { " doe", " is", " a", " developer" };

            string introduction = default;

            foreach (string word in words)
            {
                introduction = introduction + word;
            }
            //Correct
            StringBuilder stringBuilder = new();

            foreach (string word in words)
            {
                stringBuilder.Append(word).Append(" ");
            }

            return stringBuilder.ToString();
        }

        public static void ImplicitVariableType()
        {
            var numberOne = 1887092567;
            var numberTwo = 7763487897987752893;
            var numberThree = 237837469237836282M;

            int numberOne_ = 1887092567;
            long numberTwo_ = 7763487897987752893;
            decimal numberThree_ = 237837469237836282M;
        }

        public static List<int> ManualIterations()
        {
            List<int> numbers = new() { 57, 1, 4, 5, 6, 17, 3, 2, 6, 7, 13, 8, 24 };

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] + 3 >= 10)
                {
                    numbers.RemoveAt(i);
                }
            }

            //Linq
            List<int> linqResult = numbers.Where(x => x + 3 >= 10).ToList();
            return linqResult;
        }
    }

    public static class Extensions
    {
        public static string PersonExtension(this Person person)
        {
            person.name ??= "A person";
            Console.WriteLine($"{person.name} is happy");
            return person.name;
        }
    }

    public class MultipurposeMethod
    {
        static List<Person> people = new();

        public static void JackOfAllTrade()
        {
            try
            {
                Console.WriteLine("Whats your name?");
                string name = Console.ReadLine();

                Console.WriteLine("How old are you?");
                int age = Convert.ToInt32(Console.ReadLine());

                string welcomeMessage = $"Welcome to the castle {name}";
                Console.WriteLine(welcomeMessage);
                int count = 0;

                foreach (var letter in name)
                {
                    char[] vowels = { 'A', 'E', 'I', 'O', 'U' };
                    if (vowels.Contains(letter))
                        count++;
                }
                welcomeMessage = $"Your name has {count} vowel(s)";
                Console.WriteLine(welcomeMessage);


                Person person = new() { name = name, age = age };

                if (count % 2 == 0)
                {
                    person.team = "Team-even";
                }
                else
                {
                    person.team = "Team-Odd";
                }

                people.Add(person);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void HandleUser()
        {
            (string name, int age) = CollectUserInfo();

            RegisterUser(name, age);
        }

        private static (string name, int age) CollectUserInfo()
        {
            try
            {
                Console.WriteLine("Whats your name?");
                string name = Console.ReadLine();

                Console.WriteLine("How old are you?");
                int age = Convert.ToInt32(Console.ReadLine());

                string welcomeMessage = $"Welcome to the castle {name}";
                Console.WriteLine(welcomeMessage);

                return (name, age);
            }
            catch
            {
                Console.WriteLine("Age Should be a Number!");
            }
            return (default!, default);
        }
        private static int GetVowelCount(string word)
        {
            int count = 0;

            foreach (var letter in word)
            {
                char[] vowels = { 'A', 'E', 'I', 'O', 'U' };
                if (vowels.Contains(letter))
                    count++;
            }
            return count;
        }
        private static void RegisterUser(string name, int age)
        {
            int count = GetVowelCount(name);
            Person person = new() { name = name, age = age };

            if (count % 2 == 0)
            {
                person.team = "Team-even";
            }
            else
            {
                person.team = "Team-Odd";
            }
        }
    }
}
