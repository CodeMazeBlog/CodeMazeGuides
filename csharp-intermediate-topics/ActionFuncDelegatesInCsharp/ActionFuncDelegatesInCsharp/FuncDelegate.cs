namespace ActionFuncDelegatesInCsharp
{
    // Define a class that has an event that uses a Func delegate as a callback.
    public class Calculator
    {
        public event Func<int, int, int> OnAddIntegers;

        public int AddIntegers(int a, int b)
        {
            // If the OnAddIntegers event has any subscribers, invoke them.
            if (OnAddIntegers != null)
            {
                return OnAddIntegers(a, b);
            }

            // Otherwise, return the sum of the two integers.
            return a + b;
        }
    }

    public class ExecuteCalculator
    {

        public void Execute()
        {
            // Create a new Calculator object.
            Calculator calculator = new Calculator();

            // Subscribe to the OnAddIntegers event.
            calculator.OnAddIntegers += (a, b) =>
            {
                // Do something with the result of adding the two integers.
                Console.WriteLine($"The sum of {a} and {b} is {a + b}.");

                return 0; // Return a dummy value.
            };

            // Add two integers.
            int sum = calculator.AddIntegers(10, 20);

            // Output: The sum of 10 and 20 is 30.
        }


    }
}
