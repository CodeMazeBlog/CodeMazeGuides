using Moq;
using MultipleTasksDemo.Client;
using MultipleTasksDemo.Client.Contracts;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class ExecutorTests
{
    private static readonly Guid[] EmployeeIds =
    [
        new("7119e779-3054-493c-8cf7-c617b4aa0f4e"),
        new("cbb9c89f-3718-43d9-8763-b3fa3765bcea"),
        new("165bcfa8-3a4f-4850-a681-bc496616f830")
    ];

    private Mock<IEmployeeApiFacade> _apiFacade = null!;
    private Executor _executor = null!;

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

    private void AssertProfile(EmployeeProfile employeeProfile, Guid id)
    {
        _apiFacade.Verify(x => x.GetEmployeeDetails(It.IsAny<Guid>()), Times.Once);
        _apiFacade.Verify(x => x.GetEmployeeSalary(It.IsAny<Guid>()), Times.Once);
        _apiFacade.Verify(x => x.GetEmployeeRating(It.IsAny<Guid>()), Times.Once);
        Assert.That(employeeProfile.EmployeeDetails.Name, Is.EqualTo("Test Name"));
        Assert.That(employeeProfile.EmployeeDetails.Address, Is.EqualTo("Test Address"));
        Assert.That(employeeProfile.EmployeeDetails.DateOfBirth, Is.EqualTo(new DateTime(1980, 12, 01)));
        Assert.That(employeeProfile.EmployeeDetails.Id, Is.EqualTo(id));
        Assert.That(employeeProfile.Salary, Is.EqualTo(2000));
        Assert.That(employeeProfile.Rating, Is.EqualTo(4));
    }

    private void AssertAllDetails(IEnumerable<EmployeeDetails> employeeDetails)
    {
        _apiFacade.Verify(x => x.GetEmployeeDetails(It.IsAny<Guid>()), Times.Exactly(3));
        Assert.That(employeeDetails.Select(e => e.Id), Is.EquivalentTo(EmployeeIds));
    }

    [Test]
    public async Task WhenExecuteInSequenceIsInvoked_ReturnsEmployeeProfileWithAllData()
    {
        var id = Guid.NewGuid();

        AssertProfile(await _executor.ExecuteInSequence(id), id);
    }

    [Test]
    public async Task WhenExecuteInParallelUsingTaskWhenAllIsInvoked_ReturnsEmployeeProfileWithAllData()
    {
        var id = Guid.NewGuid();

        AssertProfile(await _executor.ExecuteInParallelUsingTaskWhenAll(id), id);
    }

    [Test]
    public async Task WhenExecuteInParallelIsInvoked_ReturnsEmployeeProfileWithAllData()
    {
        var id = Guid.NewGuid();

        AssertProfile(await _executor.ExecuteInParallel(id), id);
    }

    [Test]
    public async Task WhenExceptionIsThrownFromApiFacadeForExecuteInParallel_AggregateExceptionIsThrown()
    {
        _apiFacade.Setup(m => m.GetEmployeeDetails(It.IsAny<Guid>())).ThrowsAsync(new Exception("Test Exception 1"));
        _apiFacade.Setup(m => m.GetEmployeeSalary(It.IsAny<Guid>())).ThrowsAsync(new Exception("Test Exception 2"));

        var aggregateException = await Assert.ThrowsAsync<AggregateException>(
            async () => await _executor.ExecuteInParallel(Guid.NewGuid()));

        Assert.That(aggregateException!.InnerExceptions, Has.Count.EqualTo(2));
        Assert.That(aggregateException.InnerExceptions[0].Message, Is.EqualTo("Test Exception 1"));
        Assert.That(aggregateException.InnerExceptions[1].Message, Is.EqualTo("Test Exception 2"));
    }

    [Test]
    public async Task WhenExecuteUsingNormalForEachIsInvoked_ReturnsCollectionOfEmployeeDetails()
    {
        AssertAllDetails(await _executor.ExecuteUsingNormalForEach(EmployeeIds));
    }

    [Test]
    public void WhenExecuteUsingParallelForeachIsInvoked_ReturnsCollectionOfEmployeeDetails()
    {
        AssertAllDetails(_executor.ExecuteUsingParallelForeach(EmployeeIds));
    }

    [Test]
    public async Task WhenExecuteUsingParallelForeachAsyncIsInvoked_ReturnsCollectionOfEmployeeDetails()
    {
        AssertAllDetails(await _executor.ExecuteUsingParallelForeachAsync(EmployeeIds));
    }

    [Test]
    public async Task WhenExecuteUsingTaskWhenAllIsInvoked_ReturnsDetailsInInputOrder()
    {
        var employeeDetails = await _executor.ExecuteUsingTaskWhenAll(EmployeeIds);

        _apiFacade.Verify(x => x.GetEmployeeDetails(It.IsAny<Guid>()), Times.Exactly(3));
        Assert.That(employeeDetails.Select(e => e.Id), Is.EqualTo(EmployeeIds));
    }

    [Test]
    public async Task WhenExecuteUsingTaskWhenEachIsInvoked_ReturnsDetailsInCompletionOrder()
    {
        // The first id answers last and the last id answers first.
        var delays = new Dictionary<Guid, int>
        {
            [EmployeeIds[0]] = 300,
            [EmployeeIds[1]] = 150,
            [EmployeeIds[2]] = 0
        };
        _apiFacade.Setup(m => m.GetEmployeeDetails(It.IsAny<Guid>())).Returns(async (Guid id) =>
        {
            await Task.Delay(delays[id]);
            return new EmployeeDetails { Id = id };
        });

        var employeeDetails = await _executor.ExecuteUsingTaskWhenEach(EmployeeIds);

        Assert.That(employeeDetails.Select(e => e.Id), Is.EqualTo(EmployeeIds.Reverse()));
    }
}
