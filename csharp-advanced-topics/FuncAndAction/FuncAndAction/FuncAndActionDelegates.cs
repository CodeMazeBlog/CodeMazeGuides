namespace FuncAndAction
{
    public class FuncAndActionDelegates
    {
        Func<double, double> Square = new Func<double, double>(SquareNumbers);

        Action<string> WriteMessage = new Action<string>(PrintMessage);

        public static double SquareNumbers(double input1)
        {
            return Math.Pow(input1, 2);
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public double FromFunc(double num)
        {
            return Square.Invoke(num);
        }

        public void FromAction(string message)
        {
            WriteMessage.Invoke(message);
        }

    }
}
