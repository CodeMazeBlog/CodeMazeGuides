namespace ObjectInitializersInCSharp
{
    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }

        public string Description => $"Hi I am {Name}, aged {Age}";
    }
}
