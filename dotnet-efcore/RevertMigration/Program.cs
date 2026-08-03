using var db = new AirportDbContext();

Console.WriteLine("Inserting a new hangar");
db.Add(new Hangar
{
    HangarNumber = "HANGAR_01",
    HasDoors = true
});
db.SaveChanges();

var hangar = db.Hangars
    .OrderBy(h => h.Id)
    .Last();
Console.WriteLine($"Just created hangar: {hangar.HangarNumber}");

Console.WriteLine($"Inserting a new airplane");
hangar.Airplanes.Add(new Airplane
{
    TailNumber = "ABC123",
    MaxAirSpeed = 300,
    RunsOnJetFuel = true
});
db.SaveChanges();

var airplane = db.Airplanes
    .OrderBy(a => a.Id)
    .Last();
Console.WriteLine($"Just created airplane: {airplane.TailNumber} in hangar: {hangar.HangarNumber}");