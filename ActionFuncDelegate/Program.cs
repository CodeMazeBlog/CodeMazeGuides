class Program
{
    public static void Main(string[] args)
    {
        Adress testAdress = new Adress("test adress"); 
        Action displayMethod = testAdress.DisplayToConsole; 
        displayMethod();

        //assign a lambda expression
        Action showMethod = delegate () { testAdress.DisplayToConsole(); };
        showMethod();

        //func delegate with 3 inpur parameters
        Func<int, int, int, int> add = Sum; 
        int result = add(10, 10, 15); 
        Console.WriteLine(result);

        //func delegate with anonymous method
        Func<string, int, string[]> extractMeth = delegate (string s, int i) { 
            char[] delimiters = new char[] { ' ' }; 
            return i > 0 ? s.Split(delimiters, i) : s.Split(delimiters); 
        }; 
        
        string title = "The Scarlet Letter"; 
        // Use Func instance to call ExtractWords method and display result
        foreach (string word in extractMeth(title, 5)) 
            Console.WriteLine(word);

        //function delegate with lambda expression 
        Func<string, string> convert = s => s.ToUpper(); 
        string name = "CodeMaze"; 
        Console.WriteLine(convert(name));
    }

    #region Action Delegate
    public delegate void DisplayInConsole(); 
    public class Adress { 
        private string adress; 
        public Adress(string adress) { 
            this.adress = adress; 
        } 
        public void DisplayToConsole() { 
            Console.WriteLine(this.adress); 
        } 
    }
    #endregion
    #region Func delegate
    static int Sum(int x, int y, int z) { return x + y + z; }
    #endregion
}