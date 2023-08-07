namespace ReadOnlyModifierInCSharp
{
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; }

        public Person(string name)
        {
            Name = name;
        }

        public void ChangeName(string changedName)
        {
            Name = changedName;
        }
    }
}
