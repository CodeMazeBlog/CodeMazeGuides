using System.Data.Entity;
using EFInserts_EF6;
using Moq;

namespace EFInserts_EF6_Tests;

public class TestModelTests
{
    private Mock<ModelContext> MockModelContext()
    {
        var context = new Mock<ModelContext>();
        var peopleDbSet = new Mock<DbSet<Model.Person>>();
        context.SetupGet(mc => mc.People).Returns(peopleDbSet.Object);
        context.Setup(mc => mc.MockableBulkInsert(It.IsAny<IList<Model.Person>>()));
        return context;
    }
    
    [Test]
    public void WhenAddOneByOneWithSave_ThenInvokesSaveChangesBatchTimes()
    {
        // Arrange
        var context = MockModelContext();
        
        const int batchSize = 10;
        var testModel = new TestModel(context.Object)
        {
            BatchSize = batchSize
        };

        // Act
        testModel.AddOneByOneWithSave();
        
        // Assert
        context.Verify(mc => mc.People.Add(It.IsAny<Model.Person>()), Times.Exactly(batchSize));
        context.Verify(mc => mc.SaveChanges(), Times.Exactly(batchSize));
    }
    
    [Test]
    public void WhenAddOneByOne_ThenInvokesSaveChangesOnlyOnce()
    {
        // Arrange
        var context = MockModelContext();

        const int batchSize = 10;
        var testModel = new TestModel(context.Object)
        {
            BatchSize = batchSize
        };
        
        // Act
        testModel.AddOneByOne();
        
        // Assert
        context.Verify(mc => mc.People.Add(It.IsAny<Model.Person>()), Times.Exactly(batchSize));
        context.Verify(mc => mc.SaveChanges(), Times.Once);
    }
    
    [Test]
    public void WhenAddRange_ThenInvokesAddRangeAndSaveChangesOnlyOnce()
    {
        // Arrange
        var context = MockModelContext();

        const int batchSize = 10;
        var testModel = new TestModel(context.Object)
        {
            BatchSize = batchSize
        };
        
        // Act
        testModel.AddRange();
        
        // Assert
        context.Verify(mc => mc.People.AddRange(It.IsAny<IList<Model.Person>>()), Times.Once);
        context.Verify(mc => mc.SaveChanges(), Times.Once);
    }
    
    [Test]
    public void WhenBulkInsert_ThenInvokesAddRangeAndSaveChangesOnlyOnce()
    {
        // Arrange
        var context = MockModelContext();
        
        const int batchSize = 10;
        var testModel = new TestModel(context.Object)
        {
            BatchSize = batchSize
        };
        
        // Act
        testModel.BulkExtensionBulkInsert();;
        
        // Assert
        context.Verify(mc => mc.MockableBulkInsert(It.IsAny<IList<Model.Person>>()), Times.Once);
    }
}