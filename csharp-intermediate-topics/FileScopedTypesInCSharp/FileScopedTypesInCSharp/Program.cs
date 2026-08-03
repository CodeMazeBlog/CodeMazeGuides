namespace FileScopedTypesInCSharp;

public class Program
{
    public static void Main(string[] args)
    {
        var hiddenClass = new HiddenClass();
        var output = hiddenClass.Render();
        Console.WriteLine(output);
    }
}

// Output : Rendering public Hidden Class