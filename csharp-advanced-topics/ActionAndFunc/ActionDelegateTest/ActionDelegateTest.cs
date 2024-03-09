using ActionDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Test
{
    [TestClass]
    public class ActionDelegateTest
    {
        [TestMethod]
        public void TestbirthYear()
        {
            // Arrange
            int currentYear = 2024;
            int currentAge = 30;
           
            try
            {
                //Act
                Program.birthYear(currentYear, currentAge);
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}