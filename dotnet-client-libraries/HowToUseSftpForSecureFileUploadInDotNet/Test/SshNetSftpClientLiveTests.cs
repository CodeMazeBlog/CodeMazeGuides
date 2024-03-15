using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net.Sockets;
using Xunit.Abstractions;

namespace Test;

/**
 * We can easily set a test server to run these tests against using "Rebex Tiny SFTP Server"
 * 
 * https://www.rebex.net/tiny-sftp-server/
 */
public class SshNetSftpClientLiveTests
{
    private readonly ITestOutputHelper _output;

    public SshNetSftpClientLiveTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void WhenUsingSshNet_ThenCanConnectUsingUsernameAndPassword()
    {
        using SftpClient client = new("192.168.1.42", 2222, "tester", "password");
        client.Connect();

        Assert.True(client.IsConnected);

        client.Disconnect();
    }

    [Fact]
    public void WhenUsingSshNet_ThenCanConnectUsingPrivateKey()
    {
        var privateKey = new PrivateKeyFile("./ssh-keys/userkey");
        using SftpClient client = new("192.168.1.42", 2222, "tester", privateKey);
        client.Connect();

        Assert.True(client.IsConnected);

        client.Disconnect();
    }

    [Fact]
    public void WhenUsingSshNet_ThenCanCheckHostFingerprint()
    {

        var privateKey = new PrivateKeyFile("./ssh-keys/userkey");

        // Change the hardcoded fingerprint to match your test server's.
        var expectedFingerprint = Convert.FromHexString("D29B9B75F725D9164EA0D4935AFCACD3");

        using SftpClient client = new("192.168.1.42", 2222, "tester", privateKey);
        client.HostKeyReceived += delegate (object? _, HostKeyEventArgs e)
        {
            e.CanTrust = e.FingerPrint.SequenceEqual(expectedFingerprint);
        };

        client.Connect();

        Assert.True(client.IsConnected);

        client.Disconnect();
    }

    [Fact]
    public void WhenHostFingerprintCheckFails_ThenTheExceptionsIsThrown()
    {

        var privateKey = new PrivateKeyFile("./ssh-keys/userkey");
        var expectedFingerprint = Convert.FromHexString("D29B9B75F725D9164EA0D4935AFCACBB"); // Wrong host fingerprint.

        using SftpClient client = new("192.168.1.42", 2222, "tester", privateKey);
        client.HostKeyReceived += delegate (object? _, HostKeyEventArgs e)
        {
            e.CanTrust = e.FingerPrint.SequenceEqual(expectedFingerprint);
        };

        Assert.Throws<SshConnectionException>(() => client.Connect());
    }

    [Fact]
    public void WhenUsingSshNet_ThenCanUploadFile()
    {
        using SftpClient client = new("192.168.1.42", 2222, "tester", "password");

        try
        {
            client.Connect();
            if (client.IsConnected)
            {
                client.CreateDirectory("/images");
                client.UploadFile(File.OpenRead("./files/portrait.jpg"), "/images/portrait.jpg");

                _output.WriteLine("Directory listing:");
                foreach(var sftpFile in client.ListDirectory("/images"))
                {
                    _output.WriteLine($"\t{sftpFile.FullName}");
                }

                client.Disconnect();
            }
        }
        catch (Exception e)
                    when (e is SshConnectionException or SocketException or ProxyException)
        {
            _output.WriteLine($"Error connecting to server: {e.Message}");
        }
        catch (SshAuthenticationException e)
        {
            _output.WriteLine($"Failed to authenticate: {e.Message}");
        }
        catch (SftpPermissionDeniedException e)
        {
            _output.WriteLine($"Operation denied by the server: {e.Message}");
        }
        catch (SshException e)
        {
            _output.WriteLine($"Sftp Error: {e.Message}");
        }
    }
}