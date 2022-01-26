using CustomAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class PrintAttributesUnitTest
    {
        [TestMethod]
        public void WhenCorrectInput_ThenCorrectSingleAttOutput()
        {
            bool result = true;

            try
            {
                CustomAttributeHelper.GetTaskAttribute(typeof(TaskGroup));
            }
            catch
            {
                result = false;
            }

            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void WhenCorrectInput_ThenCorrectMultipleAttOutput()
        {
            bool result = true;

            try
            {
                CustomAttributeHelper.GetTaskAttributesOfMethod(typeof(TaskGroup));
            }
            catch
            {
                result = false;
            }

            Assert.IsTrue(result == true);
        }
    }
}