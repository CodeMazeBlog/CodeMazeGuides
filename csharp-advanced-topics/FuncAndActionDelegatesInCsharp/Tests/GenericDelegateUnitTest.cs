namespace Tests;


public delegate T Restaurant<T>(T arg);


public class GenericDelegateUnitTest
{
    public static Boolean MakeFood(Boolean isFoodReady)
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
    public void WhenBooleanIsSentToGenericDelagate_ThenDelegateExecutesTheReferenceMethodAndReturnsTheValue()
    {
        var chiefTestDelegate = new Restaurant<Boolean>(MakeFood);
        var result = chiefTestDelegate(true);
        Assert.AreEqual(true, result);
    }

    [Test]
    public void WhenStringIsSentToGenericDelegate_ThenDelegateExecutesTheReferenceMethodAndReturnsTheNewString(){
        var eatTheFoodTestDelegate = new Restaurant<string>(Consume);
        var result = eatTheFoodTestDelegate("pancake");
        Assert.AreEqual("I ate the pancake", result);
    }

    [Test]
    public void WhenIntegerIsSentToGenericDelegate_ThenDelegateExecutesTheReferenceMethodAnReturnsTheIntegerValue(){
        var eatTheFoodTestDelegate = new Restaurant<int>(Payment);
        var result = eatTheFoodTestDelegate(10);
        Assert.AreEqual(10, result);
    }
}