using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Data
{
    public class Seed
    {
        public void SeedData(DataContext context)
        {
            //Seeding Consoles

            context.Consoles.Add(new GameConsole
            {
                Id = 1,
                Name = "Xbox Series X",
                Manufacturer = "Microsoft"
            });

            context.Consoles.Add(new GameConsole
            {
                Id = 2,
                Name = "PlayStation 5",
                Manufacturer = "Sony"
            });

            context.Consoles.Add(new GameConsole
            {
                Id = 3,
                Name = "Nintendo Switch",
                Manufacturer = "Nintendo"
            });

            //Seeding Games

            context.Games.Add(new Game
            {
                Id = 10,
                Name = "Horizon Forbidden West",
                Publisher = "Sony Interactive Entertainment",
                ConsoleId = 2
            });

            context.Games.Add(new Game
            {
                Id = 11,
                Name = "Animal Crossing: New Horizons",
                Publisher = "Nintendo",
                ConsoleId = 3
            });

            context.Games.Add(new Game
            {
                Id = 12,
                Name = "Halo Infinite",
                Publisher = "Xbox Game Studios",
                ConsoleId = 1
            });

            context.SaveChanges();
        }
    }
}
