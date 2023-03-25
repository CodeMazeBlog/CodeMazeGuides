using ActionFuncDelegates;
using Xunit.Sdk;

namespace Tests;

public class ActionFuncDelegateUnitTest
{
    public delegate int FirstDelegate(int n);
    Action<string, int> ActionDelegate = TestMethod;
    Func<int, string, string> FuncDelegate = TestFunc;

    [Fact]
    public void WhenGivenAnInteger_ThenReturnAnInteger()
    {
        var firstDelegate = new FirstDelegate(CountTwo);

        Assert.Equal(4, firstDelegate(2));
    }

    [Fact]
    public void WhenPassedAnIntegerAndString_ThenReturnAString()
    {
        Assert.Equal("Tomie is 40 years old", FuncDelegate(40, "Tomie"));
    }


    public static int CountTwo(int number)
    {
        return number += 2;
    }
    public static void TestMethod(string name, int age)
    {
        Console.WriteLine($"{name} is {age} years old");
    }
    public static string TestFunc(int age, string name)
    {
        return $"{name} is {age} years old";
    }
}
