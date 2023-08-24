using Contracts;
using Entities.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountOwnerServerTests.Mocks
{
    internal class MockIAccountRepository
    {
        public static Mock<IAccountRepository> GetMock()
        {
            var mock = new Mock<IAccountRepository>();

            var accounts = new List<Account>()
            {
                new Account()
                {
                    OwnerId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e")
                }
            };

            mock.Setup(m => m.AccountsByOwner(It.IsAny<Guid>()))
                .Returns((Guid id) => accounts.Where(a => a.OwnerId == id).ToList());

            return mock;
        }
    }
}
