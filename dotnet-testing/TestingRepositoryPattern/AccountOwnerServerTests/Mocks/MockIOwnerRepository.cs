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
    internal class MockIOwnerRepository
    {
        public static Mock<IOwnerRepository> GetMock()
        {
            var mock = new Mock<IOwnerRepository>();

            var owners = new List<Owner>()
            {
                new Owner()
                {
                    Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    Name = "John",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            Id = new Guid(),
                            AccountType = "",
                            DateCreated = DateTime.Now
                        }

                    }
                }
            };

            mock.Setup(m => m.GetAllOwners()).Returns(() => owners);

            mock.Setup(m => m.GetOwnerById(It.IsAny<Guid>()))
                .Returns((Guid id) => owners.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.GetOwnerWithDetails(It.IsAny<Guid>()))
                .Returns((Guid id) => owners.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.CreateOwner(It.IsAny<Owner>()))
                .Callback(() => { return; });

            mock.Setup(m => m.UpdateOwner(It.IsAny<Owner>()))
               .Callback(() => { return; });

            mock.Setup(m => m.DeleteOwner(It.IsAny<Owner>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
