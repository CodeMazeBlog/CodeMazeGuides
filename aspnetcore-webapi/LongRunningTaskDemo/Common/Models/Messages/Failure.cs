namespace Common.Models.Messages
{
    public class Failure
    {
        public Guid OrderId { get; set; }
        
        public Guid CustomerId { get; set; }

        public string? Message { get; set; }

        public string? Source { get; set; }
    }
}