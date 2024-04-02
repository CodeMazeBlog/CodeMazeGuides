using System.ComponentModel.DataAnnotations;
namespace Models;

public class CustomMapPoint
{
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }
}