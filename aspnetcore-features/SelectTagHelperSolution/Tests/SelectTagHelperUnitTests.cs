using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelectTagHelper.Controllers;
using SelectTagHelper.Models;

namespace Tests
{
    [TestClass]
    public class SelectTagHelperUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new HomeController();
            var index = controller.Index() as ViewResult;
            Assert.IsNotNull(index);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var controller = new HomeController();
            var details = controller.Details() as ViewResult;
            Assert.IsNotNull(details);
        }

        [TestMethod]
        public void TestMethod3()
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
        public void TestMethod4()
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
        public void TestMethod5()
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
    }
}