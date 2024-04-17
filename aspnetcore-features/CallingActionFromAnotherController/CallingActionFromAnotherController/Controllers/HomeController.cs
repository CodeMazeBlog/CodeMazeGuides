using Microsoft.AspNetCore.Mvc;
namespace CallingActionFromAnotherController.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("List", "Product");
    }

    public IActionResult OurProduct()
    {
        return RedirectToRoute("productlist");
    }

    public IActionResult FetchProduct()
    {
        return RedirectToRoute(new
        {
            controller = "Product",
            action = "List"
        });
    }

    public IActionResult FetchProductById(int productId)
    {
        return RedirectToRoute(new
        {
            controller = "Product",
            action = "GetProductById",
            id = productId
        });
    }
}