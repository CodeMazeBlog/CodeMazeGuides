namespace ReadOnlyModifierInCSharp
{
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void ChangeName(string changedName)
        {
            Name = changedName;
        }
    }
}
