using CheckboxList.Controllers;
using CheckboxList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CheckboxListUnitTests
    {
        [TestMethod]
        public void WhenActionMethodIndex_ThenReturnNotNull()
        {
            var controller = new HomeController();
            var index = controller.Index() as ViewResult;
            Assert.IsNotNull(index);
        }

        [TestMethod]
        public void WhenActionMethodCourseSelection_ThenReturnNotNull()
        {
            var controller = new HomeController();
            var courseSelection = controller.CourseSelection() as ViewResult;
            Assert.IsNotNull(courseSelection);
        }

        [TestMethod]
        public void WhenActionMethodIndexWithInitialModel_ThenReturnEqual()
        {
            var controller = new HomeController();
            var index = controller.Index() as ViewResult;

            var expected = new InitialModel { IsChecked = false };

            var actual = index.Model as InitialModel;

            Assert.AreEqual(expected.IsChecked, actual.IsChecked);
        }

        [TestMethod]
        public void WhenActionMethodCourseSelectionWithCourses_ThenReturnEqual()
        {
            var controller = new HomeController();
            var courseSelection = controller.CourseSelection() as ViewResult;
            var expectedCourses = new List<CheckboxViewModel>
            {
                new CheckboxViewModel
                {
                    Id = 1,
                    LabelName = "Physics",
                    IsChecked = true
                },
                new CheckboxViewModel
                {
                    Id = 2,
                    LabelName = "Chemistry",
                    IsChecked = false
                },
                new CheckboxViewModel
                {
                    Id = 3,
                    LabelName = "Mathematics",
                    IsChecked = true
                },
                new CheckboxViewModel
                {
                    Id = 4,
                    LabelName = "Biology",
                    IsChecked = false
                },
            };
            var actualCourses = (List<CheckboxViewModel>)courseSelection.Model;

            Assert.AreEqual(expectedCourses.Count, actualCourses.Count);

            for (var i = 0; i < expectedCourses.Count; i++)
            {
                Assert.AreEqual(expectedCourses.ElementAt(i).Id, actualCourses.ElementAt(i).Id);
                Assert.AreEqual(expectedCourses.ElementAt(i).IsChecked, actualCourses.ElementAt(i).IsChecked);
                Assert.AreEqual(expectedCourses.ElementAt(i).LabelName, actualCourses.ElementAt(i).LabelName);
            }
        }
    }
}