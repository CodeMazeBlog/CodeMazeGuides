using Hangfire.Common;

namespace HowToPreventAHangfireJobFromRunningWhenItIsAlreadyActive.Configurations.Extensions;

public static class JobExtensions
{
    public static string GetFingerprintLockKey(this Job job)
    {
        return String.Format("{0}:lock", job.GetFingerprintKey());
    }

    public static string GetFingerprintKey(this Job job)
    {
        return String.Format("fingerprint:{0}", job.GetFingerprint());
    }
    
    private static string GetFingerprint(this Job job)
    {
        string parameters = string.Empty;
        
        if (job.Arguments != null)
        {
            parameters = string.Join(".", job.Arguments);
        }
        
        if (job.Type == null || job.Method == null)
        {
            return string.Empty;
        }
        
        var fingerprint = String.Format("{0}.{1}.{2}", job.Type.FullName, job.Method.Name, parameters);

        return fingerprint;
    }
}