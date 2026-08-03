namespace SnapshotTestingWithVerify;

public static class VehicleFactory
{
    public static Vehicle GetVehicle()
        => new()
        {
            Id = new("ebced679-45d3-4653-8791-3d969c4a986c"),
            Make = "Toyota",
            Model = "Camry",
            Year = 2022,
            Color = "Blue",
            Location = new Address("123 Main St", "Anytown", "CA", "USA"),
            Features =
            [
                "Sunroof",
                "4 Seats",
                "Navigation"
            ],
        };
}