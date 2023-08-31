using Bogus;

namespace ExpandingLIQNwithMoreLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var flight = new Flight(
                1,
                "Rome, Italy",
                "Paris, France",
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1));

            for (int i = 0; i < 30; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            var cheapestTickets = flight.GetCheapestTickets();
            Console.WriteLine($"Cheapest ticket costs: {cheapestTickets.First().Price}.");
            Console.WriteLine($"{cheapestTickets.Count()} such ticket/s sold.");

            var mostExpensiveTickets = flight.GetMostExpensiveTickets();
            Console.WriteLine($"Most expensive ticket costs: {mostExpensiveTickets.First().Price}.");
            Console.WriteLine($"{mostExpensiveTickets.Count()} such ticket/s sold.");

            var boardingGroups = flight.GetBordingGroups(4);
            Console.WriteLine($"We have {boardingGroups.Count()} boarding groups.");

            var passengersForSecurityCheck = flight.GetPassengersForSecurityCheck();
            Console.WriteLine($"We have {passengersForSecurityCheck.Count()} passengers for security check.");

            var willTakePlace = flight.WillFligthTakePlace();
            Console.WriteLine(willTakePlace);

            var areThereFreeSeats = flight.AreThereFreeSeats();
            Console.WriteLine(areThereFreeSeats);
        }

        private static Faker<Ticket> GetTicketGenerator()
        {
            return new Faker<Ticket>()
                .RuleFor(x => x.TicketNumber, f => f.Random.Int(1, 100))
                .RuleFor(x => x.SeatNumber, f => f.Random.Int(1, 100))
                .RuleFor(x => x.PassengerName, f => f.Name.FullName())
                .RuleFor(x => x.TicketClass, f => f.PickRandom("First class", "Bussines class", "Economy class"))
                .RuleFor(x => x.Price, f => f.Random.Decimal(20.00m, 250.00m));
        }

        private static Ticket GetBogusticket() => GetTicketGenerator().Generate();
    }
}