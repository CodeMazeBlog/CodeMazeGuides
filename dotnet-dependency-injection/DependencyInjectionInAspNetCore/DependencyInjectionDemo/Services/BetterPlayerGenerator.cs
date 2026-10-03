using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Services;

public class BetterPlayerGenerator : IPlayerGenerator
{
    public Player CreateNewPlayer()
    {
        return new Player
        {
            Name = "Minsc",
            Gender = Gender.Male,
            HairColor = HairColor.Black,
            Age = 35,
            Strength = 18,
            Race = "Human"
        };
    }
}
