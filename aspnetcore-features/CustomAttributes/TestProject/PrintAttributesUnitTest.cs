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

        [TestMethod]
        public void WhenGenericGetCustomAttribute_ThenTypedInstanceWithoutCast()
        {
            var descriptor = CustomAttributeHelper.GetAttributeGeneric<TaskDescriptorAttribute>(typeof(MyTasks));
            var missing = CustomAttributeHelper.GetAttributeGeneric<ManagerTaskAttribute>(typeof(MyTasks));

            Assert.IsNotNull(descriptor);
            Assert.AreEqual("The task's name", descriptor.Name);
            Assert.AreEqual(5, descriptor.DeveloperCount);
            Assert.IsNull(missing);
        }

        [TestMethod]
        public void WhenIsDefined_ThenTrueOnlyWhereTheAttributeIsApplied()
        {
            Assert.IsTrue(CustomAttributeHelper.HasAttribute<TaskDescriptorAttribute>(typeof(MyTasks)));
            Assert.IsFalse(CustomAttributeHelper.HasAttribute<ManagerTaskAttribute>(typeof(MyTasks)));
        }

        [TestMethod]
        public void WhenInheritIsTrue_ThenMemberGetCustomAttributesIgnoresItOnPropertiesOnly()
        {
            var property = typeof(TeamTaskBoard).GetProperty(nameof(TeamTaskBoard.OpenTasks))!;
            var method = typeof(TeamTaskBoard).GetMethod(nameof(TeamTaskBoard.Archive))!;

            var onProperty = CustomAttributeHelper.CountInheritedAttributes<ReviewedAttribute>(property);
            var onMethod = CustomAttributeHelper.CountInheritedAttributes<ReviewedAttribute>(method);

            Assert.AreEqual((1, 0), onProperty);
            Assert.AreEqual((1, 1), onMethod);
        }
    }
}