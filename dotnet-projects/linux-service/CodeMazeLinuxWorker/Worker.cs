namespace CodeMazeLinuxWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Code-Maze Service running at: {time}", DateTimeOffset.Now);
                _logger.LogWarning("A warning from Code-Maze Service at: {time}", DateTimeOffset.Now);
                _logger.LogError("An error from Code-Maze Service at: {time}", DateTimeOffset.Now);
                await Task.Delay(100, stoppingToken);
            }
        }
    }
}