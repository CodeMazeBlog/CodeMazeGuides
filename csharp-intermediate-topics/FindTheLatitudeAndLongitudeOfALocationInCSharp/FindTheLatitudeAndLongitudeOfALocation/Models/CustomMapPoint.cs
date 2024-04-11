namespace Models;
using System.ComponentModel.DataAnnotations;

public class CustomMapPoint
{
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }
}