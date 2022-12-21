namespace Tests;

public delegate TResult Func<out TResult>();
public delegate TResult Func<in T, out TResult>(T arg);
public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);


public class FuncDelegateUnitTest
{

    public static string OrderFood(string foodName, int amount)
    {
        return $"{amount} {foodName} is ordered";
    }
    public static double TipTheDeliveryGuy()
    {
        return 2.45;
    }

    public static string Consume(string food)
    {
        return $"I ate the {food}";
    }



    [Test]
    public void GivenParametersAreSuitable_WhenFunctionDelegate_ThenDelegateExecutesTheReferenceMethodAndReturnString()
    {
        Func<string, int, string> orderFoodTest = OrderFood;
        Func<string, string> consumeTest = Consume;

        var orderFoodResult = orderFoodTest("Burger", 1);
        var consumeResult = Consume("Burger");

        //assert
        Assert.AreEqual("1 Burger is ordered", orderFoodResult);
        Assert.AreEqual("I ate the Burger", consumeResult);
    }

    [Test]
    public void GivenParametersAreSuitable_WhenFunctionDelegate_ThenDelegateExecutesTheReferenceMethodAndReturnsDouble()
    {
        Func<double> tipTheDeliveryGuyTest = TipTheDeliveryGuy;
        var tipTheDeliveryGuyResult = tipTheDeliveryGuyTest();

        //assert
        Assert.AreEqual(2.45, tipTheDeliveryGuyResult);

    }
}