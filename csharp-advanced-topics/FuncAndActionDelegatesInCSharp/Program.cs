namespace FuncAndActionDelegatesInCSharp
{
    internal class Program
    {
        //Declare the delegate
        public delegate float DoCalculation(float x, float y);

        //Write a concrete method for the delegate
        public static float CalculateFormula(float x, float y)
        {
            return (x * y) / (x + y);
        }

        static void Main(string[] args)
        {
            //Instantiate the delegate
            DoCalculation calculate = CalculateFormula;

            //Call the delegate
            Console.WriteLine($"Formula equals {calculate(1.0f, 1.0f)}");
        }
    }
}