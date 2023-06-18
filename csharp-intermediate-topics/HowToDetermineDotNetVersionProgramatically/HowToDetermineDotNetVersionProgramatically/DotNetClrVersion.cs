namespace HowToDetermineDotNetVersionProgramatically;

public static class DotNetClrVersion
{
    public static string GetEnvironmentVersion()
    {
        return Environment.Version.ToString();
    }
}
