using Hangfire;

namespace QuartzVsHangfire.HangfireSample;

// Hangfire always needs a storage backend: the persisted queue is the product.
// This sample uses the in-memory store to stay self-contained.
public static class HangfireStorageConfig
{
    public static JobStorage UseInMemory()
    {
        GlobalConfiguration.Configuration.UseInMemoryStorage();

        // In production we swap this single line for a durable provider, e.g.
        //   config.UseSqlServerStorage(connectionString);
        //   config.UsePostgreSqlStorage(connectionString);
        // (Redis storage lives in the paid Hangfire Pro package.)
        return JobStorage.Current;
    }
}
