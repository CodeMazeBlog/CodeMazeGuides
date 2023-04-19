namespace WithoutDelegate
{
    public class WithoutDelegate
    {
        public static int Addition(int x, int y)
        {
            return x + y;
        }

        public static int Subtraction(int x, int y)
        {
            return x - y;
        }

        public static int Multiplication(int x, int y)
        {
            return x * y;
        }

        public static void Operation(string input)
        {
            if (input == "add")
            {
                Addition(10, 5);
            }
            else if (input == "subtract")
            {
                Subtraction(10, 5);
            }
            else if (input == "multiply")
            {
                Multiplication(10, 5);
            } 

            // and so on...
        }

        public static void Main(string[] args)
        {
            Operation("add");
            Operation("subtract");
            Operation("multiply");
        }
    }
}