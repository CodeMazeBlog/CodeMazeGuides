using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelectTagHelper.Models;
using SelectTagHelper.StaticData;
using System.Diagnostics;

namespace SelectTagHelper.Controllers
{
    public class HomeController : Controller
    {
        //Usage of List<SelectListItem> to render select element
        public IActionResult Index()
        {
            var model = new ProductViewModel
            {
                Products = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "Motherboards",
                        Value = "MB"
                    },
                    new SelectListItem
                    {
                        Text = "Graphic Cards",
                        Value = "GC"
                    },
                    new SelectListItem
                    {
                        Text = "Liquid Coolants",
                        Value = "LC"
                    }
                },
                Product = "GC"
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ProductViewModel model)
        {
            var selectedProduct = model.Product;

            return Content("The selected value: " + selectedProduct);
        }

        //Usage of List<EmployeeViewModel> to render select element
        public IActionResult SelectTagHelperWithComplexViewModel()
        {
            var model = new SelectViewModel
            {
                Employees = StaticRepository.GetEmployees()
            };

            return View(model);
        }

        //Usage of List<strings> to render select element
        public IActionResult SelectTagHelperWithListOfStrings()
        {
            var model = new SelectViewModel
            {
                Countries = new SelectList(StaticRepository.GetCountries())
            };

            return View(model);
        }

        //Usage of Enum to render select element
        public IActionResult SelectTagHelperWithEnum()
        {
            var model = new SampleViewModel();
            return View(model);
        }

        //Consolidated action method - renders select element using all the approaches
        public IActionResult Details()
        {
            var model = new SelectViewModel
            {
                Genders = StaticRepository.GetGenders(),
                Employees = StaticRepository.GetEmployees(),
                Countries = new SelectList(StaticRepository.GetCountries()),
                SelectedGender = "Female",
                SelectedEmployeeId = 102,
                SelectedCountry = "USA",
                SelectedDepartment = 2
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Details(SelectViewModel model)
        {
            var selectedGender = model.SelectedGender;
            var selectedEmployee = model.SelectedEmployeeId;
            var selectedCountry = model.SelectedCountry;
            var selectedDepartment = model.SelectedDepartment;

            return RedirectToAction("Details");
        }

        //Multi Select Action Method - to render multi-select dropdown
        public IActionResult MultiSelect()
        {
            var model = new MultiSelectViewModel
            {
                Employees = StaticRepository.GetEmployees()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult MultiSelect(MultiSelectViewModel model)
        {
            var selectedEmployeeIds = model.SelectedEmployeeIds;

            return RedirectToAction("MultiSelect");
        }

        //Grouped Action Method - to render grouped dropdown
        public IActionResult Grouped()
        {
            var sciences = new SelectListGroup { Name = "Science" };
            var humanities = new SelectListGroup { Name = "Humanities" };
            var model = new GroupViewModel
            {
                Courses = StaticRepository.GetCourses(sciences, humanities)
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}