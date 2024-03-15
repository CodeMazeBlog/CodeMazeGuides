public class Hangar
{
    public int Id { get; set; }
    public string? HangarNumber { get; set; }
    public bool HasDoors { get; set; }

    public List<Airplane> Airplanes { get; } = new();
}