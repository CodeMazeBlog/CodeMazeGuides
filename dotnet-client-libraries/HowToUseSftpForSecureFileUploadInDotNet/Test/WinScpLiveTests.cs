using WinSCP;
using Xunit.Abstractions;

namespace Test;

/**
 * We can easily set a test server to run these tests against using "Rebex Tiny SFTP Server"
 * 
 * https://www.rebex.net/tiny-sftp-server/
 */
public class WinScpLiveTests
{
    private readonly ITestOutputHelper _output;

    public WinScpLiveTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void WhenUsingWinScp_ThenCanUploadFileUsingPassword()
    {
        SessionOptions sessionOptions = new()
        {
            Protocol = Protocol.Sftp,
            HostName = "192.168.1.42",
            PortNumber = 2222,
            UserName = "tester",
            Password = "password",
            SshHostKeyFingerprint = "ssh-rsa 2048 uLaKVzqzc2htyHFWOLvXyweUzOLvvBL0LTsmITcabJw",
        };

        using Session session = new();
        session.Open(sessionOptions);

        session.PutFile(File.OpenRead("./files/portrait.jpg"), "/images/portrait.jpg");

        if (session.Opened)
            session.Close();
    }

    [Fact]
    public void WhenUsingWinScp_ThenCanUploadFileUsingPrivateKey()
    {
        SessionOptions sessionOptions = new()
        {
            Protocol = Protocol.Sftp,
            HostName = "192.168.1.42",
            PortNumber = 2222,
            UserName = "tester",
            // Change the hardcoded fingerprint to match your test server's.
            SshHostKeyFingerprint = "ssh-rsa 2048 uLaKVzqzc2htyHFWOLvXyweUzOLvvBL0LTsmITcabJw",
            SshPrivateKeyPath = @".\ssh-keys\userkey.ppk",
        };

        try
        {
            using Session session = new();
            session.Open(sessionOptions);

            session.CreateDirectory("/images");
            session.PutFile(File.OpenRead("./files/portrait.jpg"), "/images2/portrait.jpg");

            var directoryInfo = session.ListDirectory("/images");

            _output.WriteLine("Directory listing:");
            foreach (RemoteFileInfo file in directoryInfo.Files)
            {
                _output.WriteLine($"\t{file.FullName}");
            }

            if (session.Opened)
                session.Close();
        }
        catch (SessionRemoteException e)
        {
            _output.WriteLine(e.Message);
        }
    }
}
