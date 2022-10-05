namespace ActionAndFuncInCsharp.Interfaces
{
    public interface IProgressManager
    {
        public string CurrentMessage { get; }
        public string CurrentBarDrawing { get; }
        public string CurrentProgressValue { get; }
        public string GetProgressBarDrawing(double value);
        public void UpdateProgress(IProgress progress);
    }
}
