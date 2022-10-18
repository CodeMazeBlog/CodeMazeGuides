namespace ActionAndFuncDelegate.Functions
{
    public class FuncExample
    {
        public int RunWithParams(int number1, int number2)
        {
            //func delegate using an anonymous function
            Func<int, int, int> anonymousSumFunc = delegate (int param1, int param2)
            {
                //your business logic
                return number1 + number2;
            };

            int result = anonymousSumFunc(number1, number2);

            return result;
        }

        public int RunWithoutParams()
        {
            //func delegate using an anonymous function
            Func<int> anonymousSumFunc = delegate ()
            {
                //your business logic
                return 5 + 5;
            };

            int result = anonymousSumFunc();

            return result;
        }
    }
}
