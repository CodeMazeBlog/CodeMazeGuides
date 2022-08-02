using Microsoft.AspNetCore.Mvc;
using ReturnHTMLFromASPNETCoreWebAPI.Controllers;
using Xunit;

namespace ReturnHTMLFromASPNETCoreWebAPIUnitTest
{
    public class ReturnHTMLFromASPNETCoreWebAPIUnitTest
    {
        private readonly UserController _controller;

        public ReturnHTMLFromASPNETCoreWebAPIUnitTest()
        {
            _controller = new UserController();
        }

        [Fact]
        public void GetIndex_WhenCalled_ThenReturnsIndexHTML()
        {
            var response = _controller.Index();

            Assert.IsType<ContentResult>(response);
        }

        [Fact]
        public void GetVerify_WhenCalled_ThenReturnsVerifyHTML()
        {
            var response = _controller.Verify();

            Assert.IsType<ContentResult>(response);
        }
        
        [Fact]
        public void GetConfirmVerify_WhenCalled_ThenReturnsConfirmVerifyHTML()
        {
            var response = _controller.ConfirmVerify();

            Assert.IsType<ContentResult>(response);
        }

        [Fact]
        public void GetWelcome_WhenCalled_ThenReturnsWelcomeHTML()
        {
            var response = _controller.Welcome("John");

            Assert.IsType<ContentResult>(response);
        }
    }
}