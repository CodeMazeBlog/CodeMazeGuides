namespace GetClassNameAsString;

public class Service
{
    public string Greeting(string name)
    {
        Console.WriteLine($"{nameof(Greeting)} is called with input: {name}");

        if(string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return "Hello " + name;
    }
}
