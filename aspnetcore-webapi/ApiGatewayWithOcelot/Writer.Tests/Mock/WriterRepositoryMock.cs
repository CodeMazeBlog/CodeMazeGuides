using Moq;
using Writer.Api.Repositories.Interfaces;
using Writer.Tests.Mock.Models;

namespace Writer.Tests.Mock
{
    public class WriterRepositoryMock : Mock<IWriterRepository>
    {
        public WriterRepositoryMock GetAll()
        {
            Setup(x => x.GetAll())
                .Returns(new WriterMock().GetAll())
                .Verifiable();

            return this;
        }

        public WriterRepositoryMock GetById()
        {
            Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new WriterMock().Get())
                .Verifiable();

            return this;
        }

        public WriterRepositoryMock GetByIdNotFound()
        {
            Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new WriterMock().GetNotFound())
                .Verifiable();

            return this;
        }

        public WriterRepositoryMock InsertWriter()
        {
            Setup(x => x.Insert(It.IsAny<Writer.Api.Models.Writer>()))
                .Returns(new WriterMock().Insert())
                .Verifiable();

            return this;
        }
    }
}
