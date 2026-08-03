using Embedded_Resources_in_NET;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Reflection;

namespace Tests;

[TestClass]
public class SampleResourceReaderTests
{
    [TestMethod]
    public void GivenMainAssembly_WhenRunningListResourcesInThisAssembly_ThenExpect8LinesInConsole()
    {
        var (content, noLines) = GetConsoleOutput(SampleResourceReader.ListResourcesInThisAssembly);
        var expectedLines = 8;
        var expectedText = "Embedded_Resources_in_NET.Embedded_Resources_in_NET.sln";

        Assert.AreEqual(expectedLines, noLines);
        StringAssert.Contains(content, expectedText);
    }

    [TestMethod]
    public void GivenMainAssembly_WhenRunningListResourcesInAllAssemblies_ThenExpectKnownContent()
    {
        var (content, noLines) = GetConsoleOutput(SampleResourceReader.ListResourcesInAllAssemblies);
        var expectedText = "Embedded_Resources_in_NET.Embedded_Resources_in_NET.sln";
        var expectedText1 = "ILLink.Substitutions.xml";

        StringAssert.Contains(content, expectedText);
        StringAssert.Contains(content, expectedText1);
    }

    [TestMethod]
    public void GivenSatelliteAssembly_WhenRunningListResourcesInOurSatelliteAssembly_ThenExpect4LinesInConsole()
    {
        var (content, noLines) = GetConsoleOutput(SampleResourceReader.ListResourcesInOurSatelliteAssembly);
        var expectedLines = 4;
        var expectedText = "Embedded_Resources_in_NET_Satellite.Resources.text-file.txt";

        Assert.AreEqual(expectedLines, noLines);
        StringAssert.Contains(content, expectedText);
    }

    [TestMethod]
    public void GivenCorrectResourceName_WhenRunningFindResourceByNameAndDisplayIt_ThenExpect4LinesInConsole()
    {
        var (content, noLines) = GetConsoleOutput(() => SampleResourceReader.FindResourceByNameAndDisplayIt("Embedded_Resources_in_NET.Resources.text-file.txt"));
        var expectedLines = 4;
        var expectedText = "This is a text from an embedded text file.";

        Assert.AreEqual(expectedLines, noLines);
        StringAssert.Contains(content, expectedText);
    }

    [TestMethod]
    public void GivenIncorrectResourceName_WhenRunningFindResourceByNameAndDisplayIt_ThenExpect1LineInConsole()
    {
        var (content, noLines) = GetConsoleOutput(() => SampleResourceReader.FindResourceByNameAndDisplayIt("ResourceName"));
        var expectedLines = 1;
        var expectedText = "";

        Assert.AreEqual(expectedLines, noLines);
        Assert.AreEqual(content, expectedText);
    }

    private static (string content, int noLines) GetConsoleOutput(Action action)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        action();

        var content = stringWriter.ToString();
        return (content, content.Split('\n').Length);
    }
}
