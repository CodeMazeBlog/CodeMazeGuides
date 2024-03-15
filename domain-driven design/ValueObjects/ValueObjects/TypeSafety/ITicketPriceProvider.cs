using ValueObjects.ValueObjects;

namespace ValueObjects.TypeSafety;

public interface ITicketPriceProvider
{
    Money GetTicketPrice(Country originCountry, Station originStation, Country destinationCountry, Station destinationStation);
}