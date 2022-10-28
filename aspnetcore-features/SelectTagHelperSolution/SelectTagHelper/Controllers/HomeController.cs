using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelectTagHelper.Models;
using SelectTagHelper.StaticData;
using System.Diagnostics;

namespace SelectTagHelper.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            var model = new SelectViewModel
            {
                Genders = StaticRepository.GetGenders(),
                Employees = StaticRepository.GetEmployees(),
                SelectedEmployeeId = 102,
                Countries = new SelectList(StaticRepository.GetCountries()),
                SelectedCountry = "UK",
                SelectedDepartment = 2
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Details(SelectViewModel model)
        {
            return RedirectToAction("Details");
        }

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
            return RedirectToAction("MultiSelect");
        }

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