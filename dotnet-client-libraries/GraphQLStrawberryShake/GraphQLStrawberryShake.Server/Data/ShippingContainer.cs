using System.ComponentModel.DataAnnotations;

namespace GraphQLStrawberryShake.Server;

public class ShippingContainer
{
    public string? Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }
    public AvailableSpace? Space { get; set; }

    public class AvailableSpace
    {
        [Required]
        public double Length { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Height { get; set; }

        public double Volume => Length * Width * Height;
    }
}
