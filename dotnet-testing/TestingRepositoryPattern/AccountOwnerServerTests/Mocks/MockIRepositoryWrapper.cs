using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AccountOwnerServerTests.Mocks
{
    internal class MockIRepositoryWrapper
    {
        public static Mock<IRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IRepositoryWrapper>();
            var ownerRepoMock = MockIOwnerRepository.GetMock();
            var accountRepoMock = MockIAccountRepository.GetMock();

            mock.Setup(m => m.Owner).Returns(() => ownerRepoMock.Object);
            mock.Setup(m => m.Account).Returns(() => accountRepoMock.Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
    }
}
