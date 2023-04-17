using Delegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LoggerTests
{
    [TestMethod]
    public void LogCalculation_WithValidInputs_WritesToConsole()
    {
        using (StringWriter sw = new ())
        {
            Console.SetOut(sw);

            Logger logger = new ();
            logger.LogCalculation(3, 5);

            string expected = "Calculation performed with operands 3 and 5\r\n";
            Assert.AreEqual(expected, sw.ToString());
        }
    }
}