using BlazorbUnit;
using BlazorbUnit.Pages;
using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Xunit;

namespace Tests;

public class TestComponentTests : TestContext
{
    [Fact]
    public void GivenAValidComponent_WhenComponentIsRendered_ThenMarkupMatchesExpectedOutput()
    {
        var cut = RenderComponent<TestComponent>();

        cut.MarkupMatches("<p>Hello from TestComponent</p>");
    }

    [Fact]
    public void GivenAComponentWithAParameter_WhenComponentIsRendered_ThenMarkupMatchesExpectedOutput()
    {
        var message = "This is a message";

        var cut = RenderComponent<TestComponentWithParameter>(parameters => parameters.Add(p => p.Message, message));

        cut.MarkupMatches($"<p>Message: {message}</p>");
    }

    [Fact]
    public void GivenAComponentWithEventHandler_WhenEventHandlerIsExecuted_ThenMarkupMatchesExpectedOutput()
    {
        var cut = RenderComponent<TestComponentWithEventHandler>();

        cut.Find("button").Click(ctrlKey: true);

        cut.Find("p").MarkupMatches("<p>Control key pressed: True</p>");
    }

    [Fact]
    public void GivenAComponentWithInjectedService_WhenComponentIsRendered_ThenServiceRetrievesExpectedData()
    {
        Services.AddSingleton<IMyDataService, MyDataService>();

        var cut = RenderComponent<TestComponentWithInjection>();

        Assert.NotNull(cut.Instance.MyData);
    }

    [Fact]
    public void GivenAComponentWithJSInterop_WhenButtonIsClicked_ThenJSFunctionExecutes()
    {
        JSInterop.SetupVoid("alert", "Alert from Blazor component");

        var cut = RenderComponent<TestComponentWithJSInterop>();

        cut.Find("button").Click();

        JSInterop.VerifyInvoke("alert", calledTimes: 1);
    }

    [Fact]
    public void GivenAComponentWithInjectedHttpClient_WhenComponentIsRendered_ThenHttpClientRetrievesExpectedData()
    {
        var content = JsonSerializer.Serialize(new List<string> { "data" });

        var mockHttp = new MockHttpMessageHandler();
        var httpClient = mockHttp.ToHttpClient();
        httpClient.BaseAddress = new Uri("http://localhost");

        Services.AddSingleton(httpClient);

        mockHttp.When("/api/data")
                .Respond(HttpStatusCode.OK, "application/json", content);
        var cut = RenderComponent<TestComponentWithHttpClient>();

        cut.WaitForAssertion(() => Assert.NotNull(cut.Instance.DataFromApi));
    }

    [Fact]
    public void GivenAComponentWithNavigationManager_WhenButtonIsClicked_ThenNavigationManagerNavigatesToExpectedUri()
    {
        var navigationManager = Services.GetRequiredService<FakeNavigationManager>();
        var cut = RenderComponent<TestComponentWithNavigationManager>();

        cut.Find("button").Click();

        Assert.Equal($"{navigationManager.BaseUri}home", navigationManager.Uri);
    }
}
