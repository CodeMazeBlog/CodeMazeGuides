using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class ActionAndFuncDelegatesUnitTest
{
    //public static string DisplayMessage(string message)
    //{
    //    return message;
    //}

    [TestMethod]
    public void GivenStringMessage_WhenActionDeleGateInvoked_ThenDisplayStringMessage()
    {
        string message = "Hello World..!!";
        bool methodCalled = false;

        Action<string> actionDelegate = (message) =>
        {
            Methods.DisplayMessage(message);
            methodCalled = true;
        };

        actionDelegate.Invoke(message);

        Assert.IsTrue(methodCalled);
    }

    [TestMethod]
    public void WhenActionDelegateInvokedWithoutParameter_ThenDisplayRandomNumber()
    {
        bool methodCalled = false;

        Action showRandomNumber = () =>
        {
            Methods.DisplayRandomNumber();
            methodCalled = true;
        };

        showRandomNumber.Invoke();

        Assert.IsTrue(methodCalled);
    }

    [TestMethod]
    public void GivenTwoIntegers_WhenFuncDelegateInvoked_ThenReturnSumOfGivenNumbers()
    {
        int num1 = 12;
        int num2 = 8;

        Func<int, int, int> addition = Methods.AddNumbers;

        int result = addition.Invoke(num1, num2);

        Assert.AreEqual(num1 + num2, result);
    }

    [TestMethod]
    public void GivenFirstnameAndLastname_WhenFuncDelegateInvoked_ThenReferencedMethodCalledAndShowFullname()
    {
        string firstName = "Julia";
        string lastName = "Harris";

        string expectedResult = "My Name is Julia Harris";

        Func<string, string, string> displayFullName = Methods.ShowFullName;

        string result = displayFullName.Invoke(firstName, lastName);

        Assert.AreEqual(expectedResult, result);
    }
}