namespace action_func_delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new User("Marin", "Tanner", "marin.tanner@mail.com"),
                new User("Jakob", "Estes", "jakob.estes@mail.com"),
                new User("Tess", "Hansen", "tess.hansen@mail.com"),
                new User("Luka", "Lester", "luka.lester@mail.com")
            };

            Console.WriteLine("User names");
            DisplayUsers(users, user => Console.WriteLine($"FirstName: {user.FirstName}, LastName: {user.LastName}"));
            Console.WriteLine("User emails");
            DisplayUsers(users, user => Console.WriteLine($"Email: {user.Email}"));

            var jakob = Find(users, user => user.Email == "jakob.estes@mail.com");
            var underage = Find(users, user => user.Age < 18);

        }

        static void DisplayUsers(List<User> users, Action<User> display)
        {
            foreach (var user in users)
            {
                display(user);
            }
        }

        static User Find(List<User> users, Func<User, bool> compare)
        {
            foreach (var user in users)
            {
                if (compare(user))
                {
                    return user;
                }
            }
            return null;
        }
    }
}