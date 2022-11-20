namespace FuncAndActionDelegatesInCSharp
{
    internal class Program
    {
        //Write a concrete method for the Func system delegate
        public static float CalculateFormula(float x, float y)
        {
            return (x * y) / (x + y);
        }

        static void Main(string[] args)
        {
            //Instantiate the Func delegate
            Func<float, float, float> calculate = CalculateFormula;

            //Call the delegate
            Console.WriteLine($"Formula equals {calculate(1f, 1f)}");
        }
    }
}