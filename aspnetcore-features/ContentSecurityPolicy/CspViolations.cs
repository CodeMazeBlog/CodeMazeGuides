using System.Text.Json.Serialization;

namespace ContentSecurityPolicySample;

public class CspViolation
{
    [JsonPropertyName("csp-report")]
    public CspReport? CspReport { get; set; }
}