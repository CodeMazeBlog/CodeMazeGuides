
class Calculator
{
    // Action delegate for performing operations that don't return a value
    private Action<string> ActionDelegate;

    // Func delegate for performing operations that return a value
    private Func<int, int, int> FuncDelegate;
    
    // Action delegate that calls a func delegate 
    private Action<int, int> ActionFuncDelegate;
    public Calculator()
    {
        // Initialize the delegates with methods
        ActionDelegate = LogToConsole;
        FuncDelegate = Add;
        ActionFuncDelegate = WriteResultOfFunc;
    }

    public void Run()
    {
        while (true)
        {
            ActionDelegate("Simple Calculator");
            ActionDelegate("1. Add");
            ActionDelegate("2. Subtract");
            ActionDelegate("3. Multiply");
            ActionDelegate("4. Divide");
            ActionDelegate("5. Mod");
     
            ActionDelegate("6. Exit");
            ActionDelegate(""); 
           
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                ActionDelegate("Invalid option. Please try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    FuncDelegate = Add;
                    break;
                case 2:
                    FuncDelegate = Subtract;
                    break;
                case 3:
                    FuncDelegate = Multiply;
                    break;
                case 4:
                    FuncDelegate = Divide;
                    break;
                case 5:
                    FuncDelegate = Modulus;
                    break;
               
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    ActionDelegate("Select an option (1-6): ");

                    continue;
            }

            ActionDelegate("Enter the first number: ");
            if (!int.TryParse(Console.ReadLine(), out int num1))
            {
                ActionDelegate("Invalid input for the first number.");
                continue;
            }

            ActionDelegate("Enter the second number: ");
            if (!int.TryParse(Console.ReadLine(), out int num2))
            {
                ActionDelegate("Invalid input for the second number.");
                continue;
            }

            try
            {
                ActionFuncDelegate(num1, num2);
            }
            catch (Exception ex)
            {
                ActionDelegate(ex.Message);
            }
        }
    }

    private void LogToConsole(string message) => Console.WriteLine(message);
    private void WriteResultOfFunc(int num1, int num2)
    {
        // This method does not return a value, so it's used with the Action delegate
        Console.WriteLine("Result: " + FuncDelegate(num1, num2));
    }

    //  operations
    private int Add(int num1, int num2) => num1 + num2;

    private int Subtract(int num1, int num2)
    {
        return num1 - num2;
    }

    private int Multiply(int num1, int num2)
    {
        return num1 * num2;
    }

    private int Divide(int num1, int num2)
    {
        try
        {
            return num1 / num2;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private int Modulus(int num1, int num2)
    {
        try
        {
            return num1 % num2;
        }
        catch (Exception ex)
        {
            throw;           
        }
    }
}
