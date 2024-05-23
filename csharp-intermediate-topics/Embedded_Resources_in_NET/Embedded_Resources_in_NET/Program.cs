using Embedded_Resources_in_NET;

Console.WriteLine("\n\nResources in this assembly:\n\n");
SampleResourceReader.ListResourcesInThisAssembly();

WaitForUser();
Console.WriteLine("\n\nResources in all assemblies:\n\n");
SampleResourceReader.ListResourcesInAllAssemblies();

WaitForUser();
Console.WriteLine("\n\nResources in our satellite assembly:\n\n");
SampleResourceReader.ListResourcesInOurSatelliteAssembly();

WaitForUser();
Console.WriteLine("\n\nFind resource by name and display it:\n\n");
SampleResourceReader.FindResourceByNameAndDisplayIt("Embedded_Resources_in_NET.Resources.text-file.txt");

WaitForUser();
Console.WriteLine("\n\nFind resource by partial name and show it:\n\n");
SampleResourceReader.FindResourceByPartialNameAndShowIt("pdf-file.pdf");

static void WaitForUser()
{
    Console.WriteLine("\n\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}