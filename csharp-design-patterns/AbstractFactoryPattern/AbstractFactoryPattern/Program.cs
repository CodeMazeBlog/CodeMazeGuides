namespace AbstractFactoryPattern;

internal class Program
{
    static void Main(string[] args)
    {
        // Without Abstract Factory
        var client = new ThemeParkClient();
        client.EnjoyThemePark("Fantasy");
        Console.WriteLine();
        client.EnjoyThemePark("Adventure");
        Console.WriteLine();

        // With Abstract Factory
        var fantasyFactory = new FantasyThemeParkFactory();
        var fantasyClient = new ThemeParkClientNew(fantasyFactory);
        fantasyClient.EnjoyThemePark();
        Console.WriteLine();
        var adventureFactory = new AdventureThemeParkFactory();
        var adventureClient = new ThemeParkClientNew(adventureFactory);
        adventureClient.EnjoyThemePark();
        Console.WriteLine();
    }
}
