namespace ActionAndFuncDelegates
{
    public class ShapeBuilder
    {
        public Subject<IShape> OnShapeCreate { get; private set; } = new Subject<IShape>();

        private Func<ShapeType, IShape> _shapeFactory;

        public ShapeBuilder(Func<ShapeType, IShape> shapeFactory)
        {
            _shapeFactory = shapeFactory;
        }

        public IShape Create(ShapeType type)
        {
            IShape shape = _shapeFactory(type);
            OnShapeCreate?.Next(shape);
            return shape;
        }
    }
}
