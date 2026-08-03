using Bunit;
using DragDropPasteFileUpload.Pages;
using Microsoft.AspNetCore.Components;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Tests;
public class DragDropPasteFileUploadTest : TestContext
{
    [Fact]
    public void GivenAValidContext_WhenComponentIsRenderedForFirstTime_ThenImportsFilePasteJavaScriptFile()
    {
        // Arrange
        const string jsFileName = "./js/filePaste.js";
        JSInterop.SetupModule(jsFileName);
        JSInterop.Mode = JSRuntimeMode.Loose;

        // Act
        RenderComponent<FileUpload>();

        // Assert
        var verifyInvocation = JSInterop.VerifyInvoke("import");
        Assert.Equal(verifyInvocation.Arguments[0], jsFileName);
    }

    [Fact]
    public void GivenAValidContext_WhenComponentIsRenderedForFirstTime_ThenInvokesInitializeFilePasteFunction()
    {
        // Arrange
        const string jsFunctionName = "initializeFilePaste";
        JSInterop.SetupVoid(jsFunctionName, It.IsAny<ElementReference[]>());
        JSInterop.Mode = JSRuntimeMode.Loose;

        // Act
        RenderComponent<FileUpload>();

        // Assert
        var verifyInvocation = JSInterop.VerifyInvoke(jsFunctionName);
        Assert.IsType<ElementReference>(verifyInvocation.Arguments[0]);
        Assert.IsType<ElementReference>(verifyInvocation.Arguments[1]);
    }

    [Fact]
    public async Task GivenAValidContext_WhenComponentIsDisposed_ThenInvokesDisposeFunction()
    {
        // Arrange
        const string jsDisposeFunction = "dispose";
        JSInterop.Mode = JSRuntimeMode.Loose;

        // Act
        var cut = RenderComponent<FileUpload>();
        await cut.Instance.DisposeAsync();

        // Assert
        JSInterop.VerifyInvoke(jsDisposeFunction);
    }
}
