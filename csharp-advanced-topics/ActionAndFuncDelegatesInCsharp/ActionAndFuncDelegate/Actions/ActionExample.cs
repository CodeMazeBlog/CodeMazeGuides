namespace ActionAndFuncDelegate.Actions
{
    public class ActionExample
    {
        public int sumResult = 0;

        public void RunWithParams(int number1, int number2)
        {
            Action<int, int> anonymousSumAction = delegate (int param1, int param2)
            {
                sumResult = param1 + param2;
                Console.WriteLine($"Sum result(with parameters): {sumResult}");
            };

            anonymousSumAction(number1, number2);
        }

        public void RunWithoutParams()
        {
            Action anonymousSumAction = delegate ()
            {
                sumResult = 5 + 5;
                Console.WriteLine($"Sum result(no parameters): {sumResult}");
            };

            anonymousSumAction();
        }
    }
}
