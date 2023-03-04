namespace ActionAndFuncDelegates
{
    public class Person
    {
        public Person (string fullName, int age, char gender, string address)
        {
            FullName = fullName;
            Age = age;
            Gender = gender;
            Address = address;
        }
        public string FullName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
    }
}
