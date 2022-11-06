namespace ActionAndFuncDelegate
{
    public class Program
    {
        static void PrintToFile(string content)
        {
            File.AppendAllLines("EmployeeData.txt", new List<string>() { content });
        }

        static int Sum(int x,int y)
        {
            return x + y;
        }

        public static void Main(string[] args)
        {
            #region ActionDemo

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(1, "James", "Scott"));
            employees.Add(new Employee(2, "Mihir", "Patel"));
            employees.Add(new Employee(3, "Vickey", "Sharma"));

            Action<string> printer = new Action<string>(PrintToFile);

            printer += (x) => Console.WriteLine(x);

            foreach (var employee in employees)
            {
                employee.Print(printer);
            }

            #endregion

            #region FuncDemo

            Func<int, int, int> sumCalculator = new Func<int, int, int>(Sum);

            Console.WriteLine(sumCalculator(10, 20));

            #endregion
        }
    }
}