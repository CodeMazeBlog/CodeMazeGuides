namespace func.entities
{
    public class Calculator
    {
        public string sum { get; set; }

        public Calculator(int valueOne, int valueTwo)
        {
            Func<int, int, string> func = Sum;
            this.sum = func(valueOne, valueTwo);
        }
        public static string Sum(int valueOne, int valueTwo)
        {
            return $"SUM: {(valueOne + valueTwo)}";
        }
    }
}
