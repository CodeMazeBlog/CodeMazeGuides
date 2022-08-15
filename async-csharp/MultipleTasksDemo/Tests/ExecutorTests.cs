using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using MultipleTasksDemo.Client;
using MultipleTasksDemo.Client.Contracts;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ExecutorTests
    {
        private Mock<IEmployeeApiFacade> _apiFacade;
        private Executor _executor;

        [SetUp]
        public void Setup()
        {
            _apiFacade = new Mock<IEmployeeApiFacade>();

            _apiFacade.Setup(m => m.GetEmployeeDetails(It.IsAny<Guid>())).ReturnsAsync((Guid id) => new EmployeeDetails
            {
                Id = id,
                Name = "Test Name",
                Address = "Test Address",
                DateOfBirth = new DateTime(1980, 12, 01)
            });
            _apiFacade.Setup(m => m.GetEmployeeSalary(It.IsAny<Guid>())).ReturnsAsync(2000);
            _apiFacade.Setup(m => m.GetEmployeeRating(It.IsAny<Guid>())).ReturnsAsync(4);

            _executor = new Executor(_apiFacade.Object);
        }

        [Test]
        public async Task WhenExecuteInSequenceIsInvoked_ReturnsEmployeeProfileWithAllData()
        {
            var id = Guid.NewGuid();

            var employeeProfile = await _executor.ExecuteInSequence(id);

            _apiFacade.Verify(x => x.GetEmployeeDetails(It.IsAny<Guid>()), Times.Once);
            _apiFacade.Verify(x => x.GetEmployeeSalary(It.IsAny<Guid>()), Times.Once);
            _apiFacade.Verify(x => x.GetEmployeeRating(It.IsAny<Guid>()), Times.Once);
            Assert.AreEqual("Test Name", employeeProfile.EmployeeDetails.Name);
            Assert.AreEqual("Test Address", employeeProfile.EmployeeDetails.Address);
            Assert.AreEqual(new DateTime(1980, 12, 01), employeeProfile.EmployeeDetails.DateOfBirth);
            Assert.AreEqual(id, employeeProfile.EmployeeDetails.Id);
        }

        [Test]
        public async Task WhenExecuteInParallelIsInvoked_ReturnsEmployeeProfileWithAllData()
        {
            var id = Guid.NewGuid();

            var employeeProfile = await _executor.ExecuteInParallel(id);

            _apiFacade.Verify(x => x.GetEmployeeDetails(It.IsAny<Guid>()), Times.Once);
            _apiFacade.Verify(x => x.GetEmployeeSalary(It.IsAny<Guid>()), Times.Once);
            _apiFacade.Verify(x => x.GetEmployeeRating(It.IsAny<Guid>()), Times.Once);
            Assert.AreEqual("Test Name", employeeProfile.EmployeeDetails.Name);
            Assert.AreEqual("Test Address", employeeProfile.EmployeeDetails.Address);
            Assert.AreEqual(new DateTime(1980, 12, 01), employeeProfile.EmployeeDetails.DateOfBirth);
            Assert.AreEqual(id, employeeProfile.EmployeeDetails.Id);
        }

        [Test]
        public async Task WhenExceptinIsThrownFromApiFacadeForExecuteInParallel_AggregateExceptionisThrown()
        {
            _apiFacade.Setup(m => m.GetEmployeeDetails(It.IsAny<Guid>())).ThrowsAsync(new Exception("Test Exception 1"));
            _apiFacade.Setup(m => m.GetEmployeeSalary(It.IsAny<Guid>())).ThrowsAsync(new Exception("Test Exception 2"));            

            var aggregateException = Assert.ThrowsAsync<AggregateException>(async () => await _executor.ExecuteInParallel(Guid.NewGuid()));

            Assert.AreEqual(2, aggregateException?.InnerExceptions.Count);
            Assert.AreEqual("Test Exception 1", aggregateException?.InnerExceptions[0].Message);
            Assert.AreEqual("Test Exception 2", aggregateException?.InnerExceptions[1].Message);

        }

        [Test]
        public async Task WhenExecuteUsingNormalForEachIsInvoked_ReturnsCollectionOfEmployeeDetails()
        {
            var employeeIds = new[]
            {
                new Guid("7119e779-3054-493c-8cf7-c617b4aa0f4e"),
                new Guid("cbb9c89f-3718-43d9-8763-b3fa3765bcea"),
                new Guid("165bcfa8-3a4f-4850-a681-bc496616f830")
            };

            var employeeDetails = await _executor.ExecuteUsingNormalForEach(employeeIds);

            _apiFacade.Verify(x => x.GetEmployeeDetails(It.IsAny<Guid>()), Times.Exactly(3));
            Assert.AreEqual(3, employeeDetails.ToList().Count);
        }

        [Test]
        public async Task WhenExecuteUsingParallelForeachIsInvoked_ReturnsCollectionOfEmployeeDetails()
        {
            var employeeIds = new[]
            {
                new Guid("7119e779-3054-493c-8cf7-c617b4aa0f4e"),
                new Guid("cbb9c89f-3718-43d9-8763-b3fa3765bcea"),
                new Guid("165bcfa8-3a4f-4850-a681-bc496616f830")
            };

            var employeeDetails = await _executor.ExecuteUsingNormalForEach(employeeIds);

            _apiFacade.Verify(x => x.GetEmployeeDetails(It.IsAny<Guid>()), Times.Exactly(3));
            Assert.AreEqual(3, employeeDetails.ToList().Count);
        }

        [Test]
        public async Task WhenExecuteUsingParallelForeachAsyncIsInvoked_ReturnsCollectionOfEmployeeDetails()
        {
            var employeeIds = new[]
            {
                new Guid("7119e779-3054-493c-8cf7-c617b4aa0f4e"),
                new Guid("cbb9c89f-3718-43d9-8763-b3fa3765bcea"),
                new Guid("165bcfa8-3a4f-4850-a681-bc496616f830")
            };

            var employeeDetails = await _executor.ExecuteUsingNormalForEach(employeeIds);

            _apiFacade.Verify(x => x.GetEmployeeDetails(It.IsAny<Guid>()), Times.Exactly(3));
            Assert.AreEqual(3, employeeDetails.ToList().Count);
        }
    }
}