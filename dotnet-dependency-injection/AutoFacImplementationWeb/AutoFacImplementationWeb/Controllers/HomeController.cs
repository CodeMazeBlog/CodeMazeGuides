using AutoFacImplementationWeb.Interfaces;
using AutoFacImplementationWeb.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace AutoFacImplementationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonBusiness _personBusiness;

        public HomeController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        public IActionResult Index()
        {
            var personList = _personBusiness.GetPersonList();
            return View(personList);
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
