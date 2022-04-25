using Microsoft.AspNetCore.Mvc;
using ReturnHTMLFromASPNETCoreWebAPI.Controllers;
using Xunit;

namespace ReturnHTMLFromASPNETCoreWebAPIUnitTest
{
    public class ReturnHTMLFromASPNETCoreWebAPIUnitTest
    {
        private readonly UserController controller;

        public ReturnHTMLFromASPNETCoreWebAPIUnitTest()
        {
            controller = new UserController();
        }

        [Fact]
        public void GetIndex_WhenCalled_ReturnsIndexHTML()
        {
            var response = controller.Index();

            Assert.IsType<ContentResult>(response);
        }

        [Fact]
        public void GetVerify_WhenCalled_ReturnsVerifyHTML()
        {
            var response = controller.Verify();

            Assert.IsType<ContentResult>(response as ContentResult);
        }
        
        [Fact]
        public void GetConfirmVerify_WhenCalled_ReturnsConfirmVerifyHTML()
        {
            var response = controller.ConfirmVerify();

            Assert.IsType<ContentResult>(response);
        }

        [Fact]
        public void GetWelcome_WhenCalled_ReturnsWelcomeHTML()
        {
            var response = controller.Welcome("John");

            Assert.IsType<ContentResult>(response);
        }
    }
}