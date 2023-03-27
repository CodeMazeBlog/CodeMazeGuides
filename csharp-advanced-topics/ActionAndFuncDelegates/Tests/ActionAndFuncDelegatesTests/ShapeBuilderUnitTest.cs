using ActionAndFuncDelegates;

namespace ActionAndFuncDelegatesTests
{
    public class ShapeBuilderUnitTest
    {
        [Fact]
        public void WhenObserverIsSubscribed_ThenCorrectLogMessageIsReceived()
        {
            // arrange
            ShapeBuilder shapeBuilder = new ShapeBuilder(Program.CreateShapeFactoryMethod);
            ObjectLogger logger = new ObjectLogger();

            shapeBuilder.OnShapeCreate.Subscribe(logger.Log);

            // act
            shapeBuilder.Create(ShapeType.Circle);

            // assert
            Assert.Single(logger.Logs);
            Assert.Equal("New shape of type Circle has been created.", logger.Logs[0]);
        }
    }

    public class ObjectLogger
    {
        public List<string> Logs = new List<string>();

        public void Log(IShape shape)
        {
            Logs.Add($"New shape of type {shape.ShapeType} has been created.");
        }
    }
}