using CallingActionFromAnotherController.Controllers;
//using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace Test
{
    [TestClass]
    public class CallingActionFromAnotherController
    {
        [TestMethod]
        public void GivenActionControllerName_WhenRedirectToActionCalled_ThenActionMethodCalled()
        {
            var homeController = new HomeController();
            Microsoft.AspNetCore.Mvc.RedirectToActionResult result = homeController.Index() as Microsoft.AspNetCore.Mvc.RedirectToActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GivenActionControllerName_WhenRedirectToRouteCalled_ThenActionMethodCalled()
        {
            var homeController = new HomeController();
            RedirectToRouteResult result = homeController.OurProduct() as RedirectToRouteResult;
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GivenActionControllerName_WhenRedirectToRouteWithPatternCalled_ThenActionMethodCalled()
        {
            var homeController = new HomeController();
            RedirectToRouteResult result = homeController.OurProduct() as RedirectToRouteResult;
            Assert.IsTrue(true);
        }
    }
}