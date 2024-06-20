using GraphQLStrawberryShakeSubs.Server.Data;

namespace GraphQLStrawberryShakeSubs.Server;

public static class Seed
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.ShippingContainers.Any())
        {
            return;
        }

        var containers = new ShippingContainer[]
        {
            new()
            {
                Id = "1",
                Name = "Container 1",
                Space = new ()
                {
                    Length = 12,
                    Width = 8,
                    Height = 8
                }
            },
            new()
            {
                Id = "2",
                Name = "Container 2",
                Space = new ()
                {
                    Length = 12,
                    Width = 8,
                    Height = 8
                }
            },
            new()
            {
                Id = "3",
                Name = "Container 3",
                Space = new ()
                {
                    Length = 12,
                    Width = 8,
                    Height = 8
                }
            },
            new()
            {
                Id = "4",
                Name = "Container 4",
                Space = new ()
                {
                    Length = 12,
                    Width = 8,
                    Height = 8
                }
            }
        };

        context.ShippingContainers.AddRange(containers);
        context.SaveChanges();
    }
}
