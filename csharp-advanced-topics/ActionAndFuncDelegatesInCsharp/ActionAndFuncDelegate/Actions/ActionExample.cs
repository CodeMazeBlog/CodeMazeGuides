namespace ActionAndFuncDelegate.Actions
{
    public class ActionExample
    {
        public void RunWithParams(int number1, int number2)
        {
            //action delegate using an anonymous function
            Action<int, int> anonymousSumAction = delegate (int param1, int param2)
            {
                //your business logic
                int result = param1 + param2;
                Console.WriteLine($"Sum result(with parameters): {result}");
            };

            anonymousSumAction(number1, number2);
        }

        public void RunWithoutParams()
        {
            //action delegate using an anonymous function
            Action anonymousSumAction = delegate ()
            {
                //your business logic
                int result = 5 + 5;
                Console.WriteLine($"Sum result(no parameters): {result}");
            };

            anonymousSumAction();
        }
    }
}
