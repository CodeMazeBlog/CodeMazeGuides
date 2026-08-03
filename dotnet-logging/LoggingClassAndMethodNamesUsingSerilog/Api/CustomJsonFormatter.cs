using System.Text.Encodings.Web;
using System.Text.Json;
using Serilog.Events;
using Serilog.Formatting;

namespace Api;

public class CustomJsonFormatter : ITextFormatter
{
    private readonly JsonSerializerOptions _options;

    public CustomJsonFormatter()
    {
        _options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }

    public void Format(LogEvent logEvent, TextWriter output)
    {
        var logObject = new
        {
            Timestamp = logEvent.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff zzz"),
            Level = logEvent.Level.ToString(),
            SourceContext = GetPropertyValue(logEvent, "SourceContext"),
            Message = logEvent.RenderMessage(),
            ClassName = GetPropertyValue(logEvent, "ClassName"),
            MethodName = GetPropertyValue(logEvent, "MethodName")
        };
        output.WriteLine(JsonSerializer.Serialize(logObject, _options));
    }

    private string GetPropertyValue(LogEvent logEvent, string propertyName)
    {
        return (logEvent.Properties.ContainsKey(propertyName)
            ? ((ScalarValue)logEvent.Properties[propertyName]).Value?.ToString()
            : null)!;
    }
}
