using Exceptionless;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionlessClient.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public void Get()
    {
        throw new Exception("This is a test exception");
    }

    [HttpGet]
    [Route("manualexception")]
    public void ManualException()
    {
        try
        {
            throw new Exception("This is a manual test exception");
        }
        catch (Exception ex)
        {
            ex.ToExceptionless().Submit();
        }
    }

    [HttpGet]
    [Route("logs")]
    public void Logs()
    {
        Exceptionless.ExceptionlessClient.Default.SubmitLog("Logging a message.");
    }

    [HttpGet]
    [Route("feature")]
    public void Feature()
    {
        Exceptionless.ExceptionlessClient.Default.SubmitFeatureUsage("FeatureName");
    }

    [HttpGet]
    [Route("customstack")]
    public void CustomStack()
    {
        try
        {
            throw new ApplicationException("Unable to create new user.");
        }
        catch (Exception ex)
        {
            ex.ToExceptionless().SetManualStackingKey("UserCreationError").Submit();
        }
    }

    [HttpGet]
    [Route("dataexclusion")]
    public void DataExclusion()
    {
        Exceptionless.ExceptionlessClient.Default.Configuration.AddDataExclusions("password", "*email*");

        try
        {
            throw new ApplicationException("Unable to create new user.");
        }
        catch (Exception ex)
        {
            ex.ToExceptionless()
                .AddObject(new { User = "user1", Password = "password", UserEmail = "user1@example.com" })
                .Submit();
        }
    }

    [HttpGet]
    [Route("loglevel")]
    public void LogLevel()
    {
        Exceptionless.ExceptionlessClient.Default.SubmitLog(
            "Your log message here",
            Exceptionless.Logging.LogLevel.Trace);
    }
}