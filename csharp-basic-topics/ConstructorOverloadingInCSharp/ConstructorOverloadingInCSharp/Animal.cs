namespace ConstructorOverloadingInCSharp
{
    public class Animal
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }

        public Animal()
        {
            Name = "Daffy";
            Type = "duck";
            Age = 85;
        }

        public Animal(string name, string type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }

        public Animal(string name, string type, string age)
        {
            Name = name;
            Type = type;
            Age = Convert.ToInt32(age);
        }

        public Animal(string type, int age, string name)
        {
            Name = name;
            Type = type;
            Age = age;
        }

        public Animal(Animal animal)
        {
            Name = animal.Name;
            Type = animal.Type;
            Age = animal.Age;
        }

        public string Speak()
        {
            return string.Format("Hi! My name is {0}, and I am a {1} years old {2}.", Name, Age, Type);
        }
    }
}
