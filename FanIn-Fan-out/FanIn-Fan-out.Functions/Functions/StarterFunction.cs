using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace FanIn_Fan_out.Functions.Functions;

public static class StarterFunction
{
    [FunctionName("FanIn_FanOut_HttpStarter")]
    public static async Task<object> HttpStart(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
        [DurableClient] IDurableOrchestrationClient starter,
        ILogger log)
    {
        // Function input comes from the request content.
        string instanceId = await starter.StartNewAsync("RunOrchestrationFunctions", null);

        log.LogInformation($"Started orchestration with ID = '{instanceId}'.");
        DurableOrchestrationStatus status = await starter.GetStatusAsync(instanceId);

        while (status.RuntimeStatus == OrchestrationRuntimeStatus.Pending ||
                status.RuntimeStatus == OrchestrationRuntimeStatus.Running ||
                status.RuntimeStatus == OrchestrationRuntimeStatus.ContinuedAsNew)
        {
            await Task.Delay(10000);
            status = await starter.GetStatusAsync(instanceId);
        }

        return new ObjectResult(status);
    }
}