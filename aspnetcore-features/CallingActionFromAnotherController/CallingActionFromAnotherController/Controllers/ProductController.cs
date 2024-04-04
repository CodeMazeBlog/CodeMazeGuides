using Microsoft.AspNetCore.Mvc;

namespace CallingActionFromAnotherController.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
