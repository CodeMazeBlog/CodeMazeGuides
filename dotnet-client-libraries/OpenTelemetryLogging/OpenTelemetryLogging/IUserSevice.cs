namespace OpenTelemetryLogging;

public interface IUserSevice
{
    bool Login(string username, string password);
}