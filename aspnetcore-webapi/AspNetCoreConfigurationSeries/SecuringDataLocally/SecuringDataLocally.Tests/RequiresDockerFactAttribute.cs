using System.IO.Pipes;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace SecuringDataLocally.Tests;

/// <summary>
/// A [Fact] that is skipped when no Docker daemon is reachable, so the suite stays
/// green on a developer machine without Docker and really runs where a daemon is
/// available, starting a SQL Server container. Set
/// CONFIGURATION_SERIES_REQUIRE_DOCKER=1 to turn a missing daemon into a failure
/// instead of a skip.
/// </summary>
public sealed class RequiresDockerFactAttribute : FactAttribute
{
    public RequiresDockerFactAttribute()
    {
        if (DockerAvailability.IsAvailable || DockerAvailability.IsRequired)
            return;

        Skip = "Docker is not reachable on this machine, so the SQL Server container cannot start.";
    }
}

public static class DockerAvailability
{
    private static readonly Lazy<bool> Probe = new(Detect);

    public static bool IsAvailable => Probe.Value;

    public static bool IsRequired =>
        Environment.GetEnvironmentVariable("CONFIGURATION_SERIES_REQUIRE_DOCKER") == "1";

    // Connect to the daemon rather than looking for a socket or a pipe on disk:
    // Docker Desktop leaves its named pipe behind when it is not running, so the
    // cheaper check reports a daemon that is not there.
    private static bool Detect()
    {
        if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("DOCKER_HOST")))
            return true;

        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                using var pipe = new NamedPipeClientStream(".", "docker_engine", PipeDirection.InOut);
                pipe.Connect(timeout: 1000);

                return pipe.IsConnected;
            }

            using var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
            socket.Connect(new UnixDomainSocketEndPoint("/var/run/docker.sock"));

            return socket.Connected;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
