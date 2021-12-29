namespace ActionVsFuncDelegates
{
    public class MathAction
    {
        // define delegate of type Action 
        public Action<int, int> Operation { get; set; }

        // method to show all result in output
        public void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("Sum:");

            //Set "Operation" to "ShowSum" method and after this "Operation" point to "ShowSum"
            Operation = ShowSum;
            Operation(4, 3);
            Operation(3, 2);
            Operation(6, 1);

            Console.WriteLine();
            Console.WriteLine("Minus:");

            //Set "Operation" to "ShowMinus" method and after this "Operation" point to "ShowMinus"
            Operation = ShowMinus;
            Operation(4, 3);
            Operation(3, 2);
            Operation(6, 1);

            Console.WriteLine();
            Console.WriteLine("Multiplied:");

            //Set "Operation" to "ShowMultiplied" method and after this "Operation" point to "ShowMultiplied"
            Operation = ShowMultiplied;
            Operation(4, 3);
            Operation(3, 2);
            Operation(6, 1);
        }
        public void ShowSum(int x, int y)
        {
            Console.WriteLine($"{x} + {y} = {x + y}");
        }

        public void ShowMinus(int x, int y)
        {
            Console.WriteLine($"{x} - {y} = {x - y}");
        }

        public void ShowMultiplied(int x, int y)
        {
            Console.WriteLine($"{x} * {y} = {x * y}");
        }
    }
}
