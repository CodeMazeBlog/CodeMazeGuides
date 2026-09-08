using AccountOwnerServer.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using Xunit;

namespace AccountOwnerServer.Tests;

public class ValidateMediaTypeAttributeTests
{
    private static ActionExecutingContext ContextWith(string? accept)
    {
        var httpContext = new DefaultHttpContext();

        if (accept is not null)
            httpContext.Request.Headers.Accept = accept;

        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

        return new ActionExecutingContext(actionContext, [], new Dictionary<string, object?>(), null!);
    }

    [Fact]
    public void GivenNoAcceptHeader_WhenTheFilterRuns_ThenTheRequestIsRejected()
    {
        var context = ContextWith(null);

        new ValidateMediaTypeAttribute().OnActionExecuting(context);

        Assert.IsType<BadRequestObjectResult>(context.Result);
    }

    [Fact]
    public void GivenAHateoasAcceptHeader_WhenTheFilterRuns_ThenTheParsedMediaTypeIsStashed()
    {
        var context = ContextWith("application/vnd.codemaze.hateoas+json");

        new ValidateMediaTypeAttribute().OnActionExecuting(context);

        Assert.Null(context.Result);

        var mediaType = Assert.IsType<MediaTypeHeaderValue>(context.HttpContext.Items["AcceptHeaderMediaType"]);

        Assert.Equal("vnd.codemaze.hateoas", mediaType.SubTypeWithoutSuffix.ToString());
        Assert.Equal("json", mediaType.Suffix.ToString());
    }
}
