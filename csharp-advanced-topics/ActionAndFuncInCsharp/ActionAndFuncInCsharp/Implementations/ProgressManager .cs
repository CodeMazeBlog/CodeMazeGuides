using ActionAndFuncInCsharp.Interfaces;

namespace ActionAndFuncInCsharp.Implementations
{
    public class ProgressManager : IProgressManager
    {
        public string CurrentMessage { get; private set; }
        public string CurrentBarDrawing { get; private set; }
        public string CurrentProgressValue { get; private set; }

        public ProgressManager()
        {
            CurrentMessage = string.Empty;
            CurrentBarDrawing = string.Empty;
            CurrentProgressValue = "0 %";
        }

        public string GetProgressBarDrawing(double value)
        {
            var barPinNumber = Math.Round(value * 10);
            var barPinCounter = 0;
            var barDrawing = "";

            while (barPinCounter++ < barPinNumber)
                barDrawing += "|";

            return barDrawing;
        }

        public void UpdateProgress(IProgress progress)
        {
            CurrentMessage = progress.Message;
            CurrentBarDrawing = progress.BarDrawing;
            var progressPercentage = CalculateProgressPercentage(progress.Value);
            CurrentProgressValue = $"{progressPercentage} %";
            ShowCurrentProgress();
        }

        private int CalculateProgressPercentage(double value)
        {
            return Convert.ToInt32(value * 100);
        }

        private void ShowCurrentProgress()
        {
            Console.WriteLine(CurrentMessage);
            Console.WriteLine($"{CurrentBarDrawing} {CurrentProgressValue}");
            Thread.Sleep(1000);
        }
    }
}
