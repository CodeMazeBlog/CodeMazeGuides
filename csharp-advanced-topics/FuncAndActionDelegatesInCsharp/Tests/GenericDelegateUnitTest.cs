namespace Tests;


public delegate T Restaurant<T>(T arg);


public class GenericDelegateUnitTest
{
    public static bool MakeFood(bool isFoodReady)
    {
        return isFoodReady;
    }

    public static string Consume(string food)
    {
        return $"I ate the {food}";
    }

    public static int Payment(int price)
    {
        return price;
    }

    [Test]
    public void WhenBoolIsSentToGenericDelagate_ThenDelegateExecutesTheReferenceMethodAndReturnsTheValue()
    {
        var chiefTestDelegate = new Restaurant<bool>(MakeFood);
        var result = chiefTestDelegate(true);

        //assert
        Assert.AreEqual(true, result);
    }

    [Test]
    public void WhenStringIsSentToGenericDelegate_ThenDelegateExecutesTheReferenceMethodAndReturnsTheNewString()
    {
        var eatTheFoodTestDelegate = new Restaurant<string>(Consume);
        var result = eatTheFoodTestDelegate("pancake");

        //assert
        Assert.AreEqual("I ate the pancake", result);
    }

    [Test]
    public void WhenIntegerIsSentToGenericDelegate_ThenDelegateExecutesTheReferenceMethodAnReturnsTheIntegerValue()
    {
        var eatTheFoodTestDelegate = new Restaurant<int>(Payment);
        var result = eatTheFoodTestDelegate(10);

        //assert
        Assert.AreEqual(10, result);
    }
}