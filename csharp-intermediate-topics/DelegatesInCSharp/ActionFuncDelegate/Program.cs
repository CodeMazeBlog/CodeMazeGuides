namespace MyProject;

//Delegate Declaration
public delegate void WriterDelegate(string first, string last);

class Program
{
    public static void WriteName(string first, string last)
    {
        Console.WriteLine(first+" "+ last);
    }
    public static string JoinName(string first, string last)
    {
        return first+last;
    }
    static void Main(string[] args)
    {
        //Delegate Instantiation
        WriterDelegate writerDelegate = new WriterDelegate(WriteName);
        //Delegate Invocation
        writerDelegate("Code", "Maze");
        
        /// Types of Delegates 
        /// Action Delegate 
        
        Action<string, string> WriteFullName = WriteName;
        WriteFullName("Code", "Maze");
        
        /// Types of Delegates 
        /// Func Delegate 

        Func<string, string, string> JoinString = JoinName;
        Console.WriteLine(JoinString("code-", "maze.com"));


    }

}



//Console.WriteLine("Hello, World!");
