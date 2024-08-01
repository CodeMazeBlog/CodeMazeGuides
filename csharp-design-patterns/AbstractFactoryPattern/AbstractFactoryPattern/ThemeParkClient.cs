namespace AbstractFactoryPattern;

public class ThemeParkClient
{
    public void EnjoyThemePark(string section)
    {
        if (section == "Adventure")
        {
            var ride = new AdventureRide();
            var show = new AdventureShow();
            ride.Start();
            show.Begin();
        }
        else if (section == "Fantasy")
        {
            var ride = new FantasyRide();
            var show = new FantasyShow();
            ride.Start();
            show.Begin();
        }
    }
}
