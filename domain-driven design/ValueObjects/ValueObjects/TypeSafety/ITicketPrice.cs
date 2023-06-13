using ValueObjects.ValueObjects;

namespace ValueObjects.TypeSafety;

public interface ITicketPrice
{
    Money GetTicketPrice(Country originCountry, Country destinationCountry, Station originStation, Station destinationStation);
}