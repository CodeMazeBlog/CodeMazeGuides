using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Writer.Api.Controllers;
using Writer.Api.Repositories.Interfaces;
using Writer.Tests.Mock;

namespace Writer.Tests
{
    [TestClass]
    public class WritersControllerTests
    {
        [TestMethod]
        public void GivenTheGetEndpoint_WhenNoParameters_ThenReturnEveryWriters()
        {
            var writerRepositoryMock = new WriterRepositoryMock()
                .GetAll();

            var controller = InstantiateController(writerRepositoryMock);
            var result = controller.Get();

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public void GivenTheGetEndpoint_WhenSendIdAsParameter_ThenReturnTheWriterWithThisId()
        {
            var writerRepositoryMock = new WriterRepositoryMock()
                .GetById();

            var controller = InstantiateController(writerRepositoryMock);
            var result = controller.Get(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public void GivenTheGetEndpoint_WhenSendNotFoundIdAsParameter_ThenReturnNotFound()
        {
            var writerRepositoryMock = new WriterRepositoryMock()
                .GetByIdNotFound();

            var controller = InstantiateController(writerRepositoryMock);
            var result = controller.Get(999);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NotFoundResult);
        }

        [TestMethod]
        public void GivenThePostEndpoint_WhenSendData_ThenCreateNewWriter()
        {
            var writerRepositoryMock = new WriterRepositoryMock()
               .InsertWriter();

            var controller = InstantiateController(writerRepositoryMock);
            var result = controller.Post(new Writer.Api.Models.Writer { Id = 0, Name = "New Writer" });

            Assert.IsNotNull(result);
            Assert.IsTrue(result is CreatedResult);
        }

        public WritersController InstantiateController(WriterRepositoryMock? writerRepositoryMock = null)
        {
            var mockWriter = writerRepositoryMock ?? new Mock<IWriterRepository>();

            return new WritersController(mockWriter.Object);
        }
    }
}

