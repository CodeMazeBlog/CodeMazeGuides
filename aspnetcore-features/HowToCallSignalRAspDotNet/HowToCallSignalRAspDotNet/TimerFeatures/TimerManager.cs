namespace HowToCallSignalRAspDotNet.TimerFeatures
{
    public class TimerManager
    {
        private Timer? _timer;
        private Action? _action;

        public DateTime TimerStarted { get; set; }
        public bool IsTimerStarted { get; set; }

        public void PrepareTimer(Action action)
        {
            _action = action;

            _timer = new Timer(Execute, null, 1000, 4000);

            TimerStarted = DateTime.Now;

            IsTimerStarted = true;
        }

        public void Execute(object? stateInfo)
        {
            if (_action != null)
            {
                _action();
            }

            if ((DateTime.Now - TimerStarted).TotalSeconds > 60)
            {
                IsTimerStarted = false;

                if (_timer != null)
                {
                    _timer.Dispose();
                }
            }
        }
    }
}
