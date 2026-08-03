using Serilog;

namespace SerilogBestPractices.Enrichers;

public static class RequestEnricher
{
    public static void LogAdditionalInfo(
        IDiagnosticContext diagnosticContext, 
        HttpContext httpContext)
    {
        diagnosticContext.Set(
            "ClientIP", 
            httpContext.Connection.RemoteIpAddress?.ToString());
    }
}
