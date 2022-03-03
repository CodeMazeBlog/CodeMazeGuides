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
                CustomAttributeHelper.GetAttribute(typeof(MyTasks), typeof(TaskDescriptorAttribute));
            }
            catch
            {
                result = false;
            }

            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void WhenCorrectMyTaskInput_ThenCorrectMultipleAttOutput()
        {
            bool result = true;

            try
            {
                CustomAttributeHelper.GetAttributesOfMethods(typeof(MyTasks));
            }
            catch
            {
                result = false;
            }

            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void WhenCorrectYourTaskInput_ThenCorrectMultipleAttOutput()
        {
            bool result = true;

            try
            {
                CustomAttributeHelper.GetAttributesOfMethods(typeof(YourTasks));
            }
            catch
            {
                result = false;
            }

            Assert.IsTrue(result == true);
        }
    }
}