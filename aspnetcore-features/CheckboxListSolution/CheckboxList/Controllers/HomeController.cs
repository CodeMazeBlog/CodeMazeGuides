using CheckboxList.Data;
using CheckboxList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CheckboxList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new InitialModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(InitialModel model)
        {
            return RedirectToAction("Index");
        }

        public IActionResult CourseSelection()
        {
            var model = Repository.GetCourses();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CourseSelection(List<CheckboxViewModel> courses)
        {
            var selectedCourses = courses.Where(x => x.IsChecked).ToList();
            return RedirectToAction("CourseSelection");
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