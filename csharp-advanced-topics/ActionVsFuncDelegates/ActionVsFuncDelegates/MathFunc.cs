namespace ActionVsFuncDelegates
{
    public class MathFunc
    {
        // define delegate of type Func (2 int parameter and int result)
        public Func<int, int, int> Operation { get; set; }

        // method to show all result in output
        public void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("Sum:");

            //Set "Operation" to "GetSum" method and after this "Operation" point to "GetSum"
            Operation = GetSum;
            Console.WriteLine($"4 + 3 = {Operation(4, 3)}");
            Console.WriteLine($"3 + 2 = {Operation(3, 2)}");
            Console.WriteLine($"6 + 1 = {Operation(6, 1)}");

            Console.WriteLine();
            Console.WriteLine("Minus:");

            //Set "Operation" to "GetMinus" method and after this "Operation" point to "GetMinus"
            Operation = GetMinus;
            Console.WriteLine($"4 - 3 = {Operation(4, 3)}");
            Console.WriteLine($"3 - 2 = {Operation(3, 2)}");
            Console.WriteLine($"6 - 1 = {Operation(6, 1)}");

            Console.WriteLine();
            Console.WriteLine("Multiplied:");

            //Set "Operation" to "GetMultiplied" method and after this "Operation" point to "GetMultiplied"
            Operation = GetMultiplied;
            Console.WriteLine($"4 * 3 = {Operation(4, 3)}");
            Console.WriteLine($"3 * 2 = {Operation(3, 2)}");
            Console.WriteLine($"6 * 1 = {Operation(6, 1)}");
        }
        public int GetSum(int x, int y)
        {
            return x + y;
        }

        public int GetMinus(int x, int y)
        {
            return x - y;
        }

        public int GetMultiplied(int x, int y)
        {
            return x * y;
        }
    }
}
