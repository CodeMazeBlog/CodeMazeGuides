using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace WireMockNet
{
    public class WireMockNetExamples
    {
        public static void Examples()
        {
            var server = WireMockServer.Start(new WireMockServerSettings
            {
                Urls = new[] {
                    "http://localhost:7777/",
                    "http://localhost:8888/",
                    "http://localhost:9999/"
                },
                UseSSL = true
            });

            server
                .Given(
                    Request.Create()
                        .UsingGet()
                        .WithPath("/planets/9"))
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(HttpStatusCode.NotFound)
                        .WithRandomDelay());

            server
                .Given(
                    Request.Create()
                        .UsingGet()
                        .WithPath("/planets/3"))
                .RespondWith(
                    Response.Create()
                        .WithFault(FaultType.MALFORMED_RESPONSE_CHUNK));

            server
                .Given(
                    Request.Create()
                        .UsingGet()
                        .WithPath("/planets/4")
                        .WithHeader("AwesomeRedHeader", "MarsIsAwesome"))
                .RespondWith(
                    Response.Create()
                        .WithSuccess()
                        .WithBody("The Red Planet is responding to the awesome header"));

            server
                .Given(
                    Request.Create()
                        .UsingPost()
                        .WithPath("/planets/*"))
                .AtPriority(5)
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(HttpStatusCode.Unauthorized));

            server
                .Given(
                    Request.Create()
                    .UsingPost()
                    .WithPath("/planets/10"))
                .AtPriority(1)
                .RespondWith(
                    Response.Create()
                    .WithStatusCode(HttpStatusCode.Created));
        }
    }
}
