using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Services;

public class PlayerGenerator : IPlayerGenerator
{
    private readonly string[] _maleNames = ["Jon Irenicus", "Kagain", "Minsc", "Xzar", "Drizzt Do'Urden", "Sarevok", "Elminster"];
    private readonly string[] _femaleNames = ["Imoen", "Jaheira", "Dynaheir", "Branwen", "Bodhi", "Shar-Teel", "Safana"];

    public Player CreateNewPlayer()
    {
        string playerName;
        var random = Random.Shared;

        var playerNameIndex = random.Next(7);
        var playerGenderIndex = random.Next(2);
        var playerHairColorIndex = random.Next(7);
        var playerAge = random.Next(18, 100);
        var strength = random.Next(8, 18);

        if (playerGenderIndex == 0)
            playerName = _maleNames[playerNameIndex];
        else
            playerName = _femaleNames[playerNameIndex];

        return new Player
        {
            Name = playerName,
            Gender = (Gender)playerGenderIndex,
            HairColor = (HairColor)playerHairColorIndex,
            Age = playerAge,
            Strength = strength,
            Race = "Human"
        };
    }
}
