namespace ReadingRequestBody.SwaggerUtils;

[AttributeUsage(AttributeTargets.Method)]
public class SwaggerEnableRawTextAttribute : Attribute
{
    public SwaggerEnableRawTextAttribute()
    {
        MediaType = "text/plain";
    }

    public string MediaType { get; set; }
}
