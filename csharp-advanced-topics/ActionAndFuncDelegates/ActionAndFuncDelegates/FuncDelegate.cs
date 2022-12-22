namespace ActionAndFuncDelegatesInCSharp;

public class FuncDelegate
{
    public static void PrintFullNames()
    {
        var employees = new List<Employee>()
            {
                new() { ID = 101, FirstName = "Tony", LastName = "James" },
                new() { ID = 102, FirstName = "Terry", LastName = "John" },
                new() { ID = 103, FirstName = "Telly", LastName = "Carter" },
            };

        //Func<Employee, string> selector = employee => $"{employee.FirstName} {employee.LastName}";
        var fullNames = employees.Select(employee => $"{employee.FirstName} {employee.LastName}").ToList();

        fullNames.ForEach(Console.WriteLine);
    }
}
