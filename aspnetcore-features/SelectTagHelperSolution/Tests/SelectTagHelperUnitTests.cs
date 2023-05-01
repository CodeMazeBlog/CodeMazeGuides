using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelectTagHelper.Controllers;
using SelectTagHelper.Models;

namespace Tests
{
    [TestClass]
    public class SelectTagHelperUnitTests
    {
        [TestMethod]
        public void WhenActionMethodIndex_ThenReturnNotNull()
        {
            var controller = new HomeController();
            var index = controller.Index() as ViewResult;
            Assert.IsNotNull(index);
        }

        [TestMethod]
        public void WhenActionMethodDetails_ThenReturnNotNull()
        {
            var controller = new HomeController();
            var details = controller.Details() as ViewResult;
            Assert.IsNotNull(details);
        }

        [TestMethod]
        public void WhenActionMethodSelectTagHelperWithComplexViewModel_ThenReturnNotNull()
        {
            var controller = new HomeController();
            var view = controller.SelectTagHelperWithComplexViewModel() as ViewResult;
            Assert.IsNotNull(view);
        }

        [TestMethod]
        public void WhenActionMethodSelectTagHelperWithListOfStrings_ThenReturnNotNull()
        {
            var controller = new HomeController();
            var view = controller.SelectTagHelperWithListOfStrings() as ViewResult;
            Assert.IsNotNull(view);
        }

        [TestMethod]
        public void WhenActionMethodSelectTagHelperWithEnum_ThenReturnNotNull()
        {
            var controller = new HomeController();
            var view = controller.SelectTagHelperWithEnum() as ViewResult;
            Assert.IsNotNull(view);
        }

        [TestMethod]
        public void WhenActionMethodMultiSelect_ThenReturnNotNull()
        {
            var controller = new HomeController();
            var multiSelectView = controller.MultiSelect() as ViewResult;
            Assert.IsNotNull(multiSelectView);
        }

        [TestMethod]
        public void WhenActionMethodGrouped_ThenReturnNotNull()
        {
            var controller = new HomeController();
            var groupedView = controller.Grouped() as ViewResult;
            Assert.IsNotNull(groupedView);
        }

        [TestMethod]
        public void WhenActionMethodDetailsWithGenders_ThenReturnEqual()
        {
            var controller = new HomeController();
            var details = controller.Details() as ViewResult;
            var expectedGenders = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="Male",
                    Value="Male"
                },
                new SelectListItem
                {
                    Text="Female",
                    Value="Female"
                },
                new SelectListItem
                {
                    Text="Others",
                    Value="Others"
                }
            };
            var actualModel = (SelectViewModel)details.Model;
            var actualGenders = actualModel.Genders;

            Assert.AreEqual(expectedGenders.Count, actualGenders.Count);

            for (var i = 0; i < expectedGenders.Count; i++)
            {
                Assert.AreEqual(expectedGenders.ElementAt(i).Value, actualGenders.ElementAt(i).Value);
                Assert.AreEqual(expectedGenders.ElementAt(i).Text, actualGenders.ElementAt(i).Text);
            }
        }

        [TestMethod]
        public void WhenActionMethodDetailsWithEmployees_ThenReturnEqual()
        {
            var controller = new HomeController();
            var details = controller.Details() as ViewResult;
            var expectedEmployees = new List<EmployeeViewModel>
            {
               new EmployeeViewModel
                {
                    Id=101,
                    EmployeeName="Mark"
                },
                new EmployeeViewModel
                {
                    Id=102,
                    EmployeeName="Dave"
                },
                new EmployeeViewModel
                {
                    Id=103,
                    EmployeeName="Rosy"
                }
            };
            var actualModel = (SelectViewModel)details.Model;
            var actualEmployees = actualModel.Employees;

            Assert.AreEqual(expectedEmployees.Count, actualEmployees.Count);

            for (var i = 0; i < expectedEmployees.Count; i++)
            {
                Assert.AreEqual(expectedEmployees.ElementAt(i).Id, actualEmployees.ElementAt(i).Id);
                Assert.AreEqual(expectedEmployees.ElementAt(i).EmployeeName, actualEmployees.ElementAt(i).EmployeeName);
            }
        }

        [TestMethod]
        public void WhenActionMethodDetailsWithCountries_ThenReturnEqual()
        {
            var controller = new HomeController();
            var details = controller.Details() as ViewResult;

            var expectedCountries = new SelectList(new List<string>
            {
              "India","USA","UK","France","Germany"
            });

            var actualModel = (SelectViewModel)details.Model;
            var actualCountries = actualModel.Countries;

            Assert.AreEqual(expectedCountries.Count(), actualCountries.Count());

            for (var i = 0; i < expectedCountries.Count(); i++)
            {
                Assert.AreEqual(expectedCountries.ElementAt(i).Text, actualCountries.ElementAt(i).Text);
                Assert.AreEqual(expectedCountries.ElementAt(i).Value, actualCountries.ElementAt(i).Value);
            }
        }

        [TestMethod]
        public void WhenActionMethodGrouped_ThenReturnEqual()
        {
            var controller = new HomeController();
            var grouped = controller.Grouped() as ViewResult;

            var sciences = new SelectListGroup { Name = "Science" };
            var humanities = new SelectListGroup { Name = "Humanities" };

            var expectedCourses = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text  = "Physics",
                    Value = "PH101",
                    Group = sciences
                },
                new SelectListItem
                {
                    Text = "Chemistry",
                    Value = "CH101",
                    Group = sciences
                },
                new SelectListItem
                {
                    Text = "Mathematics",
                    Value = "MT101",
                    Group = sciences
                },
                new SelectListItem
                {
                    Text = "English",
                    Value = "EN101",
                    Group = humanities
                },
                new SelectListItem
                {
                    Text = "Environmental Studies",
                    Value = "EN101",
                    Group = humanities
                },
                new SelectListItem
                {
                    Text = "Economics",
                    Value = "EC101",
                    Group = humanities
                }
            };

            var actualModel = (GroupViewModel)grouped.Model;
            var actualCourses = actualModel.Courses;

            Assert.AreEqual(expectedCourses.Count, actualCourses.Count);

            for (var i = 0; i < expectedCourses.Count; i++)
            {
                Assert.AreEqual(expectedCourses.ElementAt(i).Text, actualCourses.ElementAt(i).Text);
                Assert.AreEqual(expectedCourses.ElementAt(i).Value, actualCourses.ElementAt(i).Value);
                Assert.AreEqual(expectedCourses.ElementAt(i).Group.Name, actualCourses.ElementAt(i).Group.Name);
            }
        }
    }
}