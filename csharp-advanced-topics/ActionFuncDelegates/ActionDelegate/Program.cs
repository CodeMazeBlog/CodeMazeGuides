namespace ActionDelegate
{
    public class Program
    {
        static void Main(string[] args)
        {            
            Action<int, int> ActionCalculator = (b, h) =>
            {
                Console.WriteLine($"The area of a rectangle is: {b * h}"); 
            };
            
            Action<string> ActionDisplayMessage = message=> 
            { 
                Console.WriteLine(message); 
            };

            ActionCalculator(4, 2);
            ActionDisplayMessage("this is an Action<T> in action");           
        }
    }
}