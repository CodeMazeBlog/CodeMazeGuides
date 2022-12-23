using System;
using System.IO;
using NUnit.Framework;


namespace Tests;


public class ActionDelegateUnitTest
{

    public static void DeliveryRecieved(string foodName, int amount, int minutes)
    {
        Console.WriteLine($"{amount} {foodName} will be delivered to you in {minutes} minutes");
        Console.WriteLine("Delivery recieved!");
    }

    public static void SayThanksToDeliveryGuy(string name)
    {
        Console.WriteLine($"Thank you {name}!");
    }

    public static void MyVoidMethod(string name, int number)
    {
        if (name == "Mike" && number == 1)
        {
            Console.WriteLine("Mike is number 1");
        }
        else
        {
            Console.WriteLine("Mike is not number 1");
        }
    }

    [Test]
    public void GivenParametersAreSuitable_WhenActionDelegate_ThenDelegateExecutesTwoConsoleWriteLineFunctions()
    {

        //arrange
        Action<string, int, int> deliveryRecievedTest = DeliveryRecieved;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        //act
        deliveryRecievedTest("pancakes", 5, 10);

        //assert
        var output = stringWriter.ToString();
        Assert.AreEqual("5 pancakes will be delivered to you in 10 minutes\nDelivery recieved!\n", output);
    }

    [Test]
    public void GivenParametersAreSuitable_WhenActionDelegate_ThenDelegateExecutesOneConsoleWriteLineFunctions()
    {

        //arrange
        Action<string, int> myVoidDelegateTest = MyVoidMethod;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        //act
        myVoidDelegateTest("Mike", 1);

        //assert
        var output = stringWriter.ToString();
        Assert.AreEqual("Mike is number 1\n", output);
    }

    [Test]
    public void GivenParametersAreSuitable_WhenActionDelegate_ThenDelegateExecutesSingleConsoleWriteLineFunction()
    {
        //arrange
        Action<string> sayThanksTest = SayThanksToDeliveryGuy;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        //act
        sayThanksTest("Eddie");

        //assert
        var output = stringWriter.ToString();
        Assert.AreEqual("Thank you Eddie!\n", output);
    }
}