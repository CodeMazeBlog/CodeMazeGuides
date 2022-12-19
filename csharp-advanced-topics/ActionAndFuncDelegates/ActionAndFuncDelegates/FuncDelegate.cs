namespace ActionAndFuncDelegatesInCSharp;

public class FuncDelegate
{
    public static void PrintFullNames()
    {
        var employees = new List<Employee>()
            {
                new Employee { ID = 101, FirstName = "Tony", LastName = "James" },
                new Employee { ID = 102, FirstName = "Terry", LastName = "John" },
                new Employee { ID = 103, FirstName = "Telly", LastName = "Carter" },
            };

        //Func<Employee, string> selector = employee => $"{employee.FirstName} {employee.LastName}";
        var fullNames = employees.Select(employee => $"{employee.FirstName} {employee.LastName}").ToList();

        fullNames.ForEach(Console.WriteLine);
    }
}
