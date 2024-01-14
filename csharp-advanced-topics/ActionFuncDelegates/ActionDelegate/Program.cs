namespace ActionDelegate
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Calculate the area of a rectangle
            Action<int, int> ActionCalculator = (b, h) =>
            {
                Console.WriteLine($"The area of a rectangle is: {b * h}");

            };

            //display a message by console.
            Action<string> ActionDisplayMessage = message=> 
            { 
                Console.WriteLine(message); 
            };

            ActionCalculator( 4, 2 );
            ActionDisplayMessage("this is an Action<T> in action");
           
        }
    }


}
