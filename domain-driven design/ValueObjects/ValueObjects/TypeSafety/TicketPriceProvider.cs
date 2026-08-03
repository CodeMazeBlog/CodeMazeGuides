using ValueObjects.ValueObjects;

namespace ValueObjects.TypeSafety;

public class TicketPriceProvider : ITicketPriceProvider
{
    public Money GetTicketPrice(Country originCountry, Station originStation, Country destinationCountry, Station destinationStation)
    {
        return Money.Create(100, "USD").Value!;
    }
}