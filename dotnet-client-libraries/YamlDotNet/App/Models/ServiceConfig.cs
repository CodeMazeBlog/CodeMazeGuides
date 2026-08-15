namespace App.Models;

public class ServiceConfig
{
    public required string ServiceName { get; set; }
    public int MaxRetries { get; set; }
}
