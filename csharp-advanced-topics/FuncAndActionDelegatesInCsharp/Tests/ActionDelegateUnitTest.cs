using System;
using System.IO;
using NUnit.Framework;


namespace Tests;

public delegate void Action<in T1>(T1 arg1);
public delegate void Action<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);

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

    [Test]
    public void GivenParametersAreSuitable_WhenActionDelegate_ThenDelegateExecutesTwoConsoleWriteLineFunctions(){
        
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
    public void GivenParametersAreSuitable_WhenActionDelegate_ThenDelegateExecutesSingleConsoleWriteLineFunction(){
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