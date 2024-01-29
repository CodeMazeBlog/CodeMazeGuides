namespace HowToCallSignalRHubFromController.TimerFeatures
{
    public class TimerManager
    {
        private Timer? _timer;

        private AutoResetEvent? _autoResetEvent;

        private Action? _action;
        public DateTime TimerStarted { get; set; }
        public bool IsTimerStarted { get; set; }
        public void PrepareTimer(Action action)
        {
            _action = action;

            _autoResetEvent = new AutoResetEvent(false);

            _timer = new Timer(Execute, _autoResetEvent, 1000, 4000);

            TimerStarted = DateTime.Now;

            IsTimerStarted = true;
        }

        public void Execute(object? stateInfo)
        {
            _action();

            if ((DateTime.Now - TimerStarted).TotalSeconds > 60)
            {
                IsTimerStarted = false;

                _timer.Dispose();
            }
        }
    }
}
