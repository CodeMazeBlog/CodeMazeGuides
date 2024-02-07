using ActionAndFuncDelegatesInCSharp;
using ActionAndFuncDelegatesInCSharp.AdvancedDelegates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ValidationException = ActionAndFuncDelegatesInCSharp.AdvancedDelegates.ValidationException;

namespace ActionAndFuncDelegatesInCSharpTests
{
    public class ExceptionHandlerServiceTests
    {
        private ExceptionHandlerService exceptionHandlerService;

        [SetUp]
        public void Setup()
        {
            exceptionHandlerService = new ExceptionHandlerService();
        }

        [Test]
        public void Given_A_ValidationException_When_Get_Error_Then_Status_Code_Is_400()
        {
            var validationException = new ValidationException();

            var result = exceptionHandlerService.GetError(validationException);

            var expected = (int)HttpStatusCode.BadRequest;
            Assert.That(result.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void Given_A_NotFoundException_When_Get_Error_Then_Status_Code_Is_404()
        {
            var notFoundException = new NotFoundException();

            var result = exceptionHandlerService.GetError(notFoundException);

            var expected = (int)HttpStatusCode.NotFound;
            Assert.That(result.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void Given_An_ArgumentException_When_Get_Error_Then_Status_Code_Is_500()
        {
            var argumentException = new ArgumentException();

            var result = exceptionHandlerService.GetError(argumentException);


            var expected = (int)HttpStatusCode.InternalServerError;
            Assert.That(result.StatusCode, Is.EqualTo(expected));
        }
    }
}
