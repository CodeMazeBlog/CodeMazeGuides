namespace TestcontainersForDotNetAndDocker.Domain;

public class Cat
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }

    public Cat(string name, int age, double weight)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
        Weight = weight;
    }
}
