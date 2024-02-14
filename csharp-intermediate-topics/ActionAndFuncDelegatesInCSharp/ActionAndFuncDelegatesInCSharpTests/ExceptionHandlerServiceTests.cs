using ActionAndFuncDelegatesInCSharp.AdvancedDelegates;
using System.Net;
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
        public void GivenAValidationException_WhenGetError_ThenStatusCodeIs400()
        {
            var validationException = new ValidationException();

            var result = exceptionHandlerService.GetError(validationException);

            var expected = (int)HttpStatusCode.BadRequest;

            Assert.That(result.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void GivenANotFoundException_WhenGetError_ThenStatusCodeIs404()
        {
            var notFoundException = new NotFoundException();

            var result = exceptionHandlerService.GetError(notFoundException);

            var expected = (int)HttpStatusCode.NotFound;

            Assert.That(result.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void GivenAnArgumentException_WhenGetError_ThenStatusCodeIs500()
        {
            var argumentException = new ArgumentException();

            var result = exceptionHandlerService.GetError(argumentException);

            var expected = (int)HttpStatusCode.InternalServerError;

            Assert.That(result.StatusCode, Is.EqualTo(expected));
        }
    }
}
