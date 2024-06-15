namespace HowToPreventAHangfireJobFromRunning.Configurations.Filters;

public class SkipConcurrentExecutionFilter : IClientFilter, IServerFilter
{
    private readonly ILogger<SkipConcurrentExecutionFilter> _logger;
    private static readonly TimeSpan DefaultLockTimeout = TimeSpan.FromSeconds(5);
    private static readonly TimeSpan FingerprintTimeout = TimeSpan.FromHours(1);

    private readonly TimeSpan _lockTimeout;
    private readonly TimeSpan _fingerprintTimeout;

    public SkipConcurrentExecutionFilter(ILogger<SkipConcurrentExecutionFilter> logger)
        : this(logger, DefaultLockTimeout, FingerprintTimeout)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public SkipConcurrentExecutionFilter(ILogger<SkipConcurrentExecutionFilter> logger, 
        TimeSpan lockTimeout, TimeSpan fingerprintTimeout)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        
        _lockTimeout = lockTimeout;
        _fingerprintTimeout = fingerprintTimeout;
    }

    public void OnCreating(CreatingContext filterContext)
    {
        if (filterContext.Job.Method.GetCustomAttributes(typeof(SkipConcurrentExecutionAttribute), false).Length == 0)
        {
            return;
        }
        
        _logger.LogInformation("Creating job '{JobName}'...", filterContext.Job.Method.Name);
        
        if (!AddFingerprintIfNotExists(filterContext.Connection, filterContext.Job))
        {
            _logger.LogWarning("Recurring job '{JobName}' is already running, skipping...", filterContext.Job.Method.Name);
            filterContext.Canceled = true;
        }
    }

    public void OnPerformed(PerformedContext filterContext)
    {
        if (filterContext.BackgroundJob.Job.Method.GetCustomAttributes(typeof(SkipConcurrentExecutionAttribute), false).Length == 0)
        {
            return;
        }

        _logger.LogInformation("Performing job '{JobName}'...", filterContext.BackgroundJob.Job.Method.Name);
        
        RemoveFingerprint(filterContext.Connection, filterContext.BackgroundJob.Job);
    }

    private bool AddFingerprintIfNotExists(IStorageConnection connection, Job job)
    {
        _logger.LogInformation("Adding fingerprint for job '{JobName}'...", job.Method.Name);
        
        using (connection.AcquireDistributedLock(job.GetFingerprintLockKey(), _lockTimeout))
        {
            var fingerprint = connection.GetAllEntriesFromHash(job.GetFingerprintKey());

            DateTimeOffset timestamp;

            if (fingerprint != null &&
                fingerprint.ContainsKey("Timestamp") &&
                DateTimeOffset.TryParseExact(fingerprint["Timestamp"], "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out timestamp) &&
                DateTimeOffset.UtcNow <= timestamp.Add(_fingerprintTimeout))
            {
                _logger.LogInformation("Fingerprint for job '{JobName}' already exists, skipping...", job.Method.Name);
                
                return false;
            }

            _logger.LogInformation("Fingerprint for job '{JobName}' does not exist, adding...", job.Method.Name);
            
            connection.SetRangeInHash(job.GetFingerprintKey(), new Dictionary<string, string>
            {
                { "Timestamp", DateTimeOffset.UtcNow.ToString("o", CultureInfo.InvariantCulture) }
            });

            return true;
        }
    }

    private void RemoveFingerprint(IStorageConnection connection, Job job)
    {
        _logger.LogInformation("Removing fingerprint for job '{JobName}'...", job.Method.Name);
        
        using (connection.AcquireDistributedLock(job.GetFingerprintLockKey(), _lockTimeout))
        using (var transaction = connection.CreateWriteTransaction())
        {
            transaction.RemoveHash(job.GetFingerprintKey());
            transaction.Commit();
            
            _logger.LogInformation("Fingerprint for job '{JobName}' removed...", job.Method.Name);
        }
    }

    void IClientFilter.OnCreated(CreatedContext filterContext)
    {
    }

    void IServerFilter.OnPerforming(PerformingContext filterContext)
    {
    }
}