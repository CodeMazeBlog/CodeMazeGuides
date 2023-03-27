namespace ActionAndFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            ShapeBuilder shapeBuilder = new ShapeBuilder(CreateShapeFactoryMethod);

            shapeBuilder.OnShapeCreate.Subscribe(StaticLogger.LogToConsole);
            shapeBuilder.OnShapeCreate.Subscribe(StaticLogger.LogToFile);

            shapeBuilder.Create(ShapeType.Circle);
            shapeBuilder.Create(ShapeType.Rectangle);
            shapeBuilder.Create(ShapeType.Circle);

            shapeBuilder.OnShapeCreate.Unsubscribe(StaticLogger.LogToConsole);
            shapeBuilder.OnShapeCreate.Unsubscribe(StaticLogger.LogToFile);

            shapeBuilder.Create(ShapeType.Circle);
            shapeBuilder.Create(ShapeType.Rectangle);
            shapeBuilder.Create(ShapeType.Circle);
        }

        public static IShape CreateShapeFactoryMethod(ShapeType shapeType) 
        {
            switch(shapeType)
            {
                case ShapeType.Circle:
                    return new Circle();
                case ShapeType.Rectangle:
                    return new Rectangle();
                default:
                    throw new ArgumentOutOfRangeException("Shape type is not valid");
            }
        }
    }
}