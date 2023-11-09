namespace RetrievingDbRowAsJsonWithDapper.Wrapper;

public interface IConfigurationWrapper
{
    string? GetConnectionString(string name);
}
