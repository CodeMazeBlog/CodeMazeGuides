namespace HowToPreventAHangfireJobFromRunning.Configurations.Filters;

// source: https://discuss.hangfire.io/t/how-do-i-prevent-creation-of-duplicate-jobs/1222/5
// source: https://gist.github.com/odinserj/a8332a3f486773baa009

public class DisableQueueingRecurringJobsFilter : JobFilterAttribute, IClientFilter, IServerFilter
{
    private readonly ILogger<DisableQueueingRecurringJobsFilter> _logger;
    private static readonly TimeSpan DefaultLockTimeout = TimeSpan.FromSeconds(5);
    private static readonly TimeSpan FingerprintTimeout = TimeSpan.FromHours(1);

    private readonly TimeSpan _lockTimeout;
    private readonly TimeSpan _fingerprintTimeout;

    public DisableQueueingRecurringJobsFilter(ILogger<DisableQueueingRecurringJobsFilter> logger)
        : this(logger, DefaultLockTimeout, FingerprintTimeout)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public DisableQueueingRecurringJobsFilter(ILogger<DisableQueueingRecurringJobsFilter> logger, 
        TimeSpan lockTimeout, TimeSpan fingerprintTimeout)
    {
        _lockTimeout = lockTimeout;
        _fingerprintTimeout = fingerprintTimeout;
    }

    public void OnCreating(CreatingContext filterContext)
    {
        if (!AddFingerprintIfNotExists(filterContext.Connection, filterContext.Job))
        {
            _logger.LogWarning("Recurring job '{0}' is already running, skipping...", filterContext.Job.Method.Name);
            filterContext.Canceled = true;
        }
    }

    public void OnPerformed(PerformedContext filterContext)
    {
        RemoveFingerprint(filterContext.Connection, filterContext.Job);
    }

    private bool AddFingerprintIfNotExists(IStorageConnection connection, Job job)
    {
        using (connection.AcquireDistributedLock(job.GetFingerprintLockKey(), _lockTimeout))
        {
            var fingerprint = connection.GetAllEntriesFromHash(job.GetFingerprintKey());

            DateTimeOffset timestamp;

            if (fingerprint != null &&
                fingerprint.ContainsKey("Timestamp") &&
                DateTimeOffset.TryParseExact(fingerprint["Timestamp"], "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out timestamp) &&
                DateTimeOffset.UtcNow <= timestamp.Add(_fingerprintTimeout))
            {
                // Actual fingerprint found, returning.
                return false;
            }

            // Fingerprint does not exist, it is invalid (no `Timestamp` key),
            // or it is not actual (timeout expired).
            connection.SetRangeInHash(job.GetFingerprintKey(), new Dictionary<string, string>
            {
                { "Timestamp", DateTimeOffset.UtcNow.ToString("o", CultureInfo.InvariantCulture) }
            });

            return true;
        }
    }

    private void RemoveFingerprint(IStorageConnection connection, Job job)
    {
        using (connection.AcquireDistributedLock(job.GetFingerprintLockKey(), _lockTimeout))
        using (var transaction = connection.CreateWriteTransaction())
        {
            transaction.RemoveHash(job.GetFingerprintKey());
            transaction.Commit();
        }
    }

    void IClientFilter.OnCreated(CreatedContext filterContext)
    {
    }

    void IServerFilter.OnPerforming(PerformingContext filterContext)
    {
    }
}