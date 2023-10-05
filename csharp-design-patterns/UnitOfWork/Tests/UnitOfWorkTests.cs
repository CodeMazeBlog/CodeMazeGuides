using Moq;
using UnitOfWork.DataAccess;
using UnitOfWork.Entities;
using UnitOfWork.Repositories;

namespace Tests;

public class UnitOfWorkTests
{
    [Test]
    public async Task GivenARepository_WhenUsingUnitOfWork_ThenItShouldNotPersistChangesBeforeCommit()
    {
        var transactionMock = new Mock<ITransaction>();
        transactionMock.Setup(x => x.CommitAsync()).Returns(Task.CompletedTask);
        transactionMock.Setup(x => x.RollbackAsync()).Returns(Task.CompletedTask);
        var databaseMock = new Mock<IStore>();
        databaseMock.Setup(x => x.BeginTransactionAsync()).ReturnsAsync(transactionMock.Object);
        databaseMock.Setup(x => x.GetEntitySet<Order>()).Returns(new List<Order>().AsQueryable());
        var unitOfWork = new UnitOfWork.DataAccess.UnitOfWork(databaseMock.Object);
        var orderRepository = new OrderRepository(databaseMock.Object);
        
        await unitOfWork.BeginTransactionAsync();

        orderRepository.Add(new Order());
        
        transactionMock.Verify(x => x.CommitAsync(), Times.Never);
        transactionMock.Verify(x => x.RollbackAsync(), Times.Never);
        
        await unitOfWork.CommitAsync();
        
        transactionMock.Verify(x => x.CommitAsync(), Times.Once);
        transactionMock.Verify(x => x.RollbackAsync(), Times.Never);
    }
}