public class Airplane
{
    public int Id { get; set; }
    public string? TailNumber { get; set; }
    public int? NumberOfEngines { get; set; }
    public double? MaxAirSpeed { get; set; }
    public bool? RunsOnJetFuel { get; set; }

    public int? HangarId { get; set; }
    public Hangar? Hangar { get; set; }
}