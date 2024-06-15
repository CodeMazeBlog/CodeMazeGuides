namespace HowToPreventAHangfireJobFromRunning.Configurations.Extensions;

public static class JobExtensions
{
    public static string GetFingerprintLockKey(this Job job)
    {
        return $"{job.GetFingerprintKey()}:lock";
    }

    public static string GetFingerprintKey(this Job job)
    {
        return $"fingerprint:{job.GetFingerprint()}";
    }
    
    private static string GetFingerprint(this Job job)
    {
        var parameters = string.Empty;

        if (job.Args is not null)
        {
            parameters = string.Join(".", job.Args);
        }

        if (job.Type == null || job.Method == null)
        {
            return string.Empty;
        }

        var fingerprint = $"{job.Type.FullName}.{job.Method.Name}.{parameters}";

        return fingerprint;
    }
}