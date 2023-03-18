
using System.Xml.Linq;



public class Adress {

    public delegate void DisplayInConsole();

    private string adress; 
    public Adress(string adress) { 
        this.adress = adress; 
    } 

    public void DisplayToConsole() { 
        Console.WriteLine(this.adress); 
    }
}

public class testTestDelegate
{
    public static int Sum(int x, int y, int z) { return x + y + z; }

    public static void Main() { 
        Adress testAdress = new Adress("test adress"); 
        Action displayMethod = testAdress.DisplayToConsole; 
        displayMethod();

        //test using a lambda expression 
        Adress testName = new Adress("test lambda action");
        Action showMethod = () => testName.DisplayToConsole();
        showMethod();

        //func delegate

        Func<int, int, int, int> add = Sum; 
        int result = add(10, 10, 15); 
        Console.WriteLine(result);

        //func delegate with anounymous method
        Func<string, int, string[]> extractMeth = delegate (string s, int i) { 
            char[] delimiters = new char[] { ' ' }; 
            return i > 0 ? s.Split(delimiters, i) : s.Split(delimiters); 
        }; 
        string title = "The Scarlet Letter"; 
        // Use Func instance to call ExtractWords method and display result
        foreach (string word in extractMeth(title, 5)) 
            Console.WriteLine(word);

        //func delegate with lambda expression

        Func<string, string> convert = s => s.ToUpper(); 
        string name = "CodeMaze";
        Console.WriteLine(convert(name));
    }
}