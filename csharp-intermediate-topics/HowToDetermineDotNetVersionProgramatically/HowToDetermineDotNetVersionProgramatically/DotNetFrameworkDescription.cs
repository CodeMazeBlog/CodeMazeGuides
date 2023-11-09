using System.Runtime.InteropServices;

namespace HowToDetermineDotNetVersionProgramatically;

public static class DotNetFrameworkDescription
{
    public static string GetFrameworkDescription()
    {
        return RuntimeInformation.FrameworkDescription;
    }
}