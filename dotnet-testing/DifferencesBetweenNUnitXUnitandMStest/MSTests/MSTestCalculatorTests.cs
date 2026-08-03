namespace MSTests;

[TestClass]
public class MSTestCalculatorTests
{
    [TestMethod]
    [TestCategory("Multiplication")]
    [TestCategory("PositiveNumbers")]
    public void GivenTwoIntegers_WhenMultiplied_ThenShouldReturnPositiveProduct()
    {
        var result = Calculator.Multiply(3, 7);

        Assert.AreEqual(21, result);
    }

    [TestMethod]
    [TestCategory("Multiplication")]
    [TestCategory("NegativeNumbers")]
    public void GivenTwoIntegers_WhenMultiplied_ThenShouldReturnCorrectNegativeProduct()
    {
        var result = Calculator.Multiply(-3, 7);

        Assert.AreEqual(-21, result);
    }

    [TestMethod]
    [DataRow(0, 0, 0)]
    [DataRow(5, 2, 10)]
    [DataRow(-3, 7, -21)]
    public void GivenTwoIntegers_WhenMultiplied_ThenReturnsProductUsingDataRow(int a, int b, int expected)
    {
        var result = Calculator.Multiply(a, b);

        Assert.AreEqual(result, expected);
    }

    [TestMethod]
    [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
    public void GivenDynamicTestData_WhenMultiplied_ThenReturnsProduct(int a, int b, int expected)
    {
        var actual = Calculator.Multiply(a, b);
        Assert.AreEqual(expected, actual);
    }
    public static IEnumerable<object[]> GetData()
    {
        yield return new object[] { 1, 2, 2 };
        yield return new object[] { 12, 30, 360 };
        yield return new object[] { 14, 1, 14 };
    }
}