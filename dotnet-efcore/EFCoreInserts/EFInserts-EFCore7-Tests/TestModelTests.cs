using EFInserts_EFCore7;
using Moq;

namespace EFInserts_EFCore7_Tests;

public class TestModelTests
{
    [Test]
    public void WhenAddOneByOneWithSave_ThenInvokesSaveChangesBatchTimes()
    {
        // Arrange
        const int batchSize = 10;
        var context = new Mock<ModelContext>();
        var testModel = new TestModel(context.Object)
        {
            BatchSize = batchSize
        };
        
        // Act
        testModel.AddOneByOneWithSave();
        
        // Assert
        context.Verify(mc => mc.Add(It.IsAny<Model.Person>()), Times.Exactly(batchSize));
        context.Verify(mc => mc.SaveChanges(), Times.Exactly(batchSize));
    }
    
    [Test]
    public void WhenAddOneByOne_ThenInvokesSaveChangesOnlyOnce()
    {
        // Arrange
        const int batchSize = 10;
        var context = new Mock<ModelContext>();
        var testModel = new TestModel(context.Object)
        {
            BatchSize = batchSize
        };
        
        // Act
        testModel.AddOneByOne();
        
        // Assert
        context.Verify(mc => mc.Add(It.IsAny<Model.Person>()), Times.Exactly(batchSize));
        context.Verify(mc => mc.SaveChanges(), Times.Once);
    }
    
    [Test]
    public void WhenAddRange_ThenInvokesAddRangeAndSaveChangesOnlyOnce()
    {
        // Arrange
        const int batchSize = 10;
        var context = new Mock<ModelContext>();
        var testModel = new TestModel(context.Object)
        {
            BatchSize = batchSize
        };
        
        // Act
        testModel.AddRange();
        
        // Assert
        context.Verify(mc => mc.AddRange(It.IsAny<IList<Model.Person>>()), Times.Once);
        context.Verify(mc => mc.SaveChanges(), Times.Once);
    }
    
    [Test]
    public void WhenBulkInsert_ThenInvokesAddRangeAndSaveChangesOnlyOnce()
    {
        // Arrange
        const int batchSize = 10;
        var context = new Mock<ModelContext> { DefaultValue = DefaultValue.Mock };
        context.Setup(mc => mc.MockableBulkInsert(It.IsAny<IList<Model.Person>>()));
        
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