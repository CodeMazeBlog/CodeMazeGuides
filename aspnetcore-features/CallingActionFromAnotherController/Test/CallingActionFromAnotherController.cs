using CallingActionFromAnotherController.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Test;

[TestClass]
public class CallingActionFromAnotherController
{
    [TestMethod]
    public void GivenActionControllerName_WhenRedirectToActionCalled_ThenActionMethodCalled()
    {
        var homeController = new HomeController();
        var result = homeController.Index() as RedirectToActionResult;

        Assert.AreEqual("List", result?.ActionName);
    }

    [TestMethod]
    public void GivenActionControllerName_WhenRedirectToRouteCalled_ThenActionMethodCalled()
    {
        var homeController = new HomeController();
        var result = homeController.OurProduct() as RedirectToRouteResult;

        Assert.AreEqual("productlist", result?.RouteName);
    }

    [TestMethod]
    public void GivenActionControllerName_WhenRedirectToRouteWithPatternCalled_ThenActionMethodCalled()
    {
        var homeController = new HomeController();
        var result = homeController.OurProduct() as RedirectToRouteResult;

        Assert.AreEqual("productlist", result?.RouteName);
    }

    [TestMethod]
    public void GivenProductId_WhenActionMethodCalled_ThenRedirectToActionCalled()
    {
        var homeController = new HomeController();
        var result = homeController.AddProductToCart(1);
        
        Assert.AreEqual("Cart", ((Microsoft.AspNetCore.Mvc.RedirectToActionResult)result).ActionName);
    }
}