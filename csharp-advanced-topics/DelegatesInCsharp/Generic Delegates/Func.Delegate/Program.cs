namespace Func.Delegate
{
    internal class Program 
    { 
        static void Main(string[] args) 
        { 
            Func<string, int> lengthText = StringLength;
            var result = lengthText("Generic delegates are an important topic in C#"); 
            Console.WriteLine($"The length of the text is {result}"); 
        } 
        static int StringLength(string strText) 
        { return strText.Length; 
        } 
    }
}