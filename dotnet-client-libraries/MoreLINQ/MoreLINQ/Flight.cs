using MoreLinq;

namespace ExpandingLIQNwithMoreLINQ
{
    public class Flight
    {
        private readonly int MinNumberOfTickets = 20;
        private readonly int MaxNumberOfTickets = 50;

        public int FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Flight(
            int flightNumber,
            string departureCity,
            string arrivalCity,
            DateTime departureTime,
            DateTime arrivalTime)
        {
            FlightNumber = flightNumber;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Tickets = new List<Ticket>();
        }

        public void AddTicket(Ticket ticket)
        {
            if (!AreThereFreeSeats())
            {
                Console.WriteLine("No free seats on the plane!");
            }
            else
            {
                Tickets.Add(ticket);
            }
        }

        public IEnumerable<Ticket> GetCheapestTickets()
        {
            return MoreEnumerable.MinBy(Tickets, x => x.Price);
        }

        public IEnumerable<Ticket> GetMostExpensiveTickets()
        {
            return MoreEnumerable.MaxBy(Tickets, x => x.Price);
        }

        public bool AreThereFreeSeats()
        {
            return MoreEnumerable.AtMost(Tickets, MaxNumberOfTickets - 1);
        }

        public bool WillFligthTakePlace()
        {
            return MoreEnumerable.CountBetween(Tickets, MinNumberOfTickets, MaxNumberOfTickets);
        }

        public IEnumerable<IEnumerable<Ticket>> GetBordingGroups(int numberOfGroups)
        {
            var groupSize = (int)Math.Ceiling((double)Tickets.Count / numberOfGroups);

            return MoreEnumerable.Batch(Tickets, groupSize);
        }

        public IEnumerable<Ticket> GetPassengersForSecurityCheck()
        {
            var ticketsInRandomOrder = MoreEnumerable.Shuffle(Tickets);

            return MoreEnumerable.TakeEvery(ticketsInRandomOrder, 5);
        }
    }
}
