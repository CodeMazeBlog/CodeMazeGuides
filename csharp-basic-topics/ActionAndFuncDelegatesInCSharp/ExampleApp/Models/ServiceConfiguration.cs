namespace ExampleApp.Models
{
    public record ServiceConfiguration
    {
        public string? Name { get; set; }

        public bool IsActive { get; set; }
    }
}