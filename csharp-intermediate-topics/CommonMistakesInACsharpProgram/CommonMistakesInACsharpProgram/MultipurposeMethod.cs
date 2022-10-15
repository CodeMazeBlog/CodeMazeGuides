namespace CommonMistakesInACsharpProgram
{
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

                foreach (var letter in name.ToLower())
                {
                    char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                    if (vowels.Contains(letter))
                        count++;
                }
                welcomeMessage = $"Your name has {count} vowel(s)";
                Console.WriteLine(welcomeMessage);


                Person person = new() { Name = name, Age = age };

                if (count % 2 == 0)
                {
                    person.Team = "Team-even";
                }
                else
                {
                    person.Team = "Team-Odd";
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
            Person person = new() { Name = name, Age = age };

            if (count % 2 == 0)
            {
                person.Team = "Team-even";
            }
            else
            {
                person.Team = "Team-Odd";
            }
        }
    }
}
