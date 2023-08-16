namespace ReadOnlyModifierInCSharp
{
    public class Person
    {
        private readonly int _age;

        public int Age => _age;
        public string Name { get; private set; }

        public Person(string name, int age)
        {
            Name = name;
            _age = age;
        }

        public void ChangeName(string changedName)
        {
            Name = changedName;
        }
    }
}
