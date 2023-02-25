namespace AccessModifiersInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            calculator.Value = 15;
            var result = calculator.IncrementValue(calculator.Value);

            Console.WriteLine(result);

            var account = new BankAccount();

            account.Deposit(100);
            var balance = account.GetBalance();

            Console.WriteLine(balance);

            var rectangle = new Rectangle(10, 5);

            var area = rectangle.GetArea();

            Console.WriteLine(area);

            var logger = new Logger();

            var messageLog = logger.LogMessage("This is a message");

            Console.WriteLine(messageLog);

            var manager = new Manager();
            var managerDetails = manager.GetEmployeeDetails();

            Console.WriteLine(managerDetails);
        }
    }
}