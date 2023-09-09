namespace action_func_delegates
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public User(string firstName, string lastName, string email, int age = 18)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
        }
    }
}
