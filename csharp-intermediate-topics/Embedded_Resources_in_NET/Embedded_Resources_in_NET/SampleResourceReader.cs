using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

namespace Embedded_Resources_in_NET;

public class SampleResourceReader
{
    public static void ListResourcesInThisAssembly() 
        => ListResourcesInAssembly(ThisAssembly);

    public static void ListResourcesInAllAssemblies() 
        => AllAssembliesOfCurrentAppDomain.ToList().ForEach(ListResourcesInAssembly);

    public static void ListResourcesInOurSatelliteAssembly()
        => ListResourcesInAssembly(SatelliteAssembly);

    public static void FindResourceByNameAndDisplayIt(string resourceName)
        => DisplayResource(resourceName, FindResourceByName);

    public static void FindResourceByPartialNameAndShowIt(string partialResourceName)
        => ShowResource(partialResourceName, FindResourceByPartialName);

    private static void DisplayResource(string resourceName, Func<string, Stream?> getResourceStream)
    {
        var resourceStream = getResourceStream(resourceName);
        if (resourceStream is not null)
            DisplayResource(resourceName, resourceStream);
    }

    private static void DisplayResource(string resourceName, Stream resourceStream)
    {
        using var reader = new StreamReader(resourceStream);
        var resourceContent = reader.ReadToEnd();
        Console.WriteLine($"Resource {resourceName} content:");
        Console.WriteLine(resourceContent);
    }

    private static void ShowResource(string partialResourceName, Func<string, Stream?> getResourceStream)
    {
        var resourceStream = getResourceStream(partialResourceName);
        if (resourceStream is not null)
            ShowFile(SaveResourceToAFile(partialResourceName, resourceStream));
    }

    private static string SaveResourceToAFile(string partialResourceName, Stream resourceStream)
    {
        var tempFileName = Path.Combine(Path.GetTempPath(), partialResourceName);
        using var fileStream = new FileStream(tempFileName, FileMode.Create, FileAccess.Write);
        resourceStream.CopyTo(fileStream);
        fileStream.Close();

        return tempFileName;
    }

    private static void ShowFile(string fileName)
        => Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });

    private static Assembly ThisAssembly
        => typeof(SampleResourceReader).Assembly;

    private static Assembly[] AllAssembliesOfCurrentAppDomain
        => AppDomain.CurrentDomain.GetAssemblies();

    private static Assembly SatelliteAssembly =>
        Assembly.Load("Embedded_Resources_in_NET_Satellite");

    private static Stream? FindResourceByName(string resourceName)
        => FindResource(names => names?.FirstOrDefault(rn => rn == resourceName));

    private static Stream? FindResourceByPartialName(string partialResourceName)
        => FindResource(names => names?.FirstOrDefault(rn => rn.Contains(partialResourceName)));

    private static Stream? FindResource(Func<string[]?, string?> finder)
    {
        foreach (var assembly in AllAssembliesOfCurrentAppDomain)
        {
            var resourceNames = assembly.GetManifestResourceNames();
            var resourceName = finder(resourceNames);

            if (resourceName is not null)
            {
                Console.WriteLine($"Resource {resourceName} found in {assembly.FullName}");
                return assembly.GetManifestResourceStream(resourceName);
            }
        }

        return null;
    }

    private static void ListResourcesInAssembly(Assembly? assembly)
    {
        if (assembly is null) 
            return;

        var resources = assembly.GetManifestResourceNames();
        if (resources.Length == 0)
            return;

        Console.WriteLine($"Resources in {assembly.FullName}");
        foreach (var resource in resources)
        {
            Console.WriteLine(resource);
        }

        Console.WriteLine();
    }
}
