namespace ActionAndFuncInCsharp.Interfaces
{
    public interface IProgress
    {
        public string Message { get; }
        public string BarDrawing { get; }
        public double Value { get; }
    }
}
