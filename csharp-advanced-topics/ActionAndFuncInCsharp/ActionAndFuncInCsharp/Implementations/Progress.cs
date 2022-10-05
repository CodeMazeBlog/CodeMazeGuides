using ActionAndFuncInCsharp.Interfaces;

namespace ActionAndFuncInCsharp.Implementations
{
    public class Progress : IProgress
    {
        public string Message { get; }
        public double Value { get; }
        public string BarDrawing { get; }

        public Progress(string message, double value, string barDrawing)
        {
            Message = message;
            Value = value;
            BarDrawing = barDrawing;
        }
    }
}
