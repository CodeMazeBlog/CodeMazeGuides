using System.Diagnostics;

namespace AccountOwnerServer.Tests
{
    // These tests need a SQL Server container. Where Docker is not available they report
    // as skipped with a reason, never as passed: a green run that silently tested nothing
    // is worse than a red one.
    public sealed class DockerFactAttribute : FactAttribute
    {
        public DockerFactAttribute()
        {
            if (!DockerEnvironment.IsAvailable.Value)
            {
                Skip = "Docker is not available here, so the SQL Server container cannot start.";
            }
        }
    }

    internal static class DockerEnvironment
    {
        public static readonly Lazy<bool> IsAvailable = new(Probe);

        private static bool Probe()
        {
            try
            {
                using var process = Process.Start(new ProcessStartInfo("docker", "version --format {{.Server.Version}}")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                });

                if (process is null)
                {
                    return false;
                }

                return process.WaitForExit(milliseconds: 20_000) && process.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
