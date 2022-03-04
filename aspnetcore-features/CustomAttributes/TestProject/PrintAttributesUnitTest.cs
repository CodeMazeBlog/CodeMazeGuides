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
            var attribute = CustomAttributeHelper.GetAttribute(typeof(MyTasks), typeof(TaskDescriptorAttribute));
            
            Assert.IsTrue(attribute == typeof(TaskDescriptorAttribute).ToString());
        }

        [TestMethod]
        public void WhenCorrectMyTaskInput_ThenCorrectMultipleAttOutput()
        {
            var attList = CustomAttributeHelper.GetAttributesOfMethods(typeof(MyTasks));

            var result = attList.FindAll(x => x.Contains("ScheduleMeeting-" + typeof(DeveloperTaskAttribute))).Count == 2;
            result &= attList.FindAll(x => x.Contains("ScheduleInterview-" + typeof(DeveloperTaskAttribute))).Count == 1;
            result &= attList.FindAll(x => x.Contains("ScheduleInterview-" + typeof(ManagerTaskAttribute))).Count == 1;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenCorrectYourTaskInput_ThenCorrectMultipleAttOutput()
        {
            var attList = CustomAttributeHelper.GetAttributesOfMethods(typeof(YourTasks));

            var result = attList.FindAll(x => x.Contains("ScheduleInterview-" + typeof(DeveloperTaskAttribute))).Count == 2;

            Assert.IsTrue(result);
        }
    }
}