using System.Collections;
using System.Reflection;
using DynamicTypeInCSharp.Factories;
using DynamicTypeInCSharp.Models;

namespace DynamicTypeInCSharp;

public static class Examples
{
    public static void ExampleDeclaration()
    {
        var isbn = "978-1617294532";

        dynamic intNumber = 12;
        dynamic book = new Book(isbn);

        Console.WriteLine(intNumber.GetType());
        Console.WriteLine(book.Isbn);
    }

    public static void ExampleDynamicWithException()
    {
        dynamic testVariable = 5;
        Console.WriteLine(testVariable.GetType());

        testVariable = "Hello World";
        Console.WriteLine(testVariable.GetType());

        Console.WriteLine(testVariable++);
    }

    public static void ExampleMissingMethodDefinitionException()
    {
        dynamic logger = LoggerFactory.GetLogger();
        logger.LogInfo("Hi");
        logger.LogWarning("You are about to enter a time warp");
        logger.LogError("System is malfunctioning");
        logger.LogTrace("Communication lost");
    }

    public static WorkStatus ExampleReflection()
    {
        EmployeeFactory employeeFactory = GetEmployeeFactory();
        object firstEmployee = employeeFactory.GetFirstEmployee();
        Type firstEmployeeType = firstEmployee.GetType();
        object? workStatusObject = firstEmployeeType.InvokeMember("GetWorkStatus",
            BindingFlags.InvokeMethod, null, firstEmployee, null);
        var workStatus = (WorkStatus)workStatusObject!;

        Console.WriteLine(workStatus);

        return workStatus;
    }

    public static WorkStatus ExampleDynamic()
    {
        EmployeeFactory employeeFactory = GetEmployeeFactory();
        dynamic firstEmployee = employeeFactory.GetFirstEmployee();
        WorkStatus workStatus = firstEmployee.GetWorkStatus();

        Console.WriteLine(workStatus);

        return workStatus;
    }

    public static void ExampleVarObjectDynamic()
    {
        var imNumber = 10; //implicitly typed variable
        int exNumber = 10; //explicitly typed variable

        object testObj = 10;
        testObj = (int)testObj + 10;

        dynamic testDynamic = 10;
        testDynamic = testDynamic + 25;

        Console.WriteLine($"{imNumber} {exNumber} {testObj} {testDynamic}");
    }

    public static void ExamplePrintCount(ICollection collection)
    {
        dynamic dynamicCollection = collection;
        Console.WriteLine("Static typing: {0}", collection.Count);
        Console.WriteLine("Dynamic typing: {0}", dynamicCollection.Count);
    }

    private static EmployeeFactory GetEmployeeFactory()
    {
        var employeeFactory = new EmployeeFactory();
        employeeFactory.Add(new Employee { Id = "1", Name = "Johnny Depp" });

        return employeeFactory;
    }
}
