using Delegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Add_WithValidInputs_RaisesCalculationPerformedEvent()
    {
        Calculator calculator = new ();
        bool eventRaised = false;

        calculator.CalculationPerformed += (x, y) => eventRaised = true;

        int result = calculator.Add(3, 5);

        Assert.IsTrue(eventRaised);
    }

    [TestMethod]
    public void Subtract_WithValidInputs_RaisesCalculationPerformedEvent()
    {
        Calculator calculator = new ();
        bool eventRaised = false;

        calculator.CalculationPerformed += (x, y) => eventRaised = true;

        int result = calculator.Subtract(5, 3);

        Assert.IsTrue(eventRaised);
    }
}
