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

            Tickets.Add(ticket);
        }

        public Ticket GetCheapestTicket()
        {
            var cheapestPrice = Tickets.Min(t => t.Price);
            return Tickets.First(x => x.Price == cheapestPrice);
        }

        public Ticket GetMostExpensiveTicket()
        {
            var highestPrice = Tickets.Max(t => t.Price);
            return Tickets.First(x => x.Price == highestPrice);
        }

        public bool AreThereFreeSeats()
        {
            return Tickets.Count < MaxNumberOfTickets;
        }

        public bool WillFligthTakePlace()
        {
            return Tickets.Count >= MaxNumberOfTickets && Tickets.Count <= MaxNumberOfTickets;
        }

        public IEnumerable<Ticket> GetBordingGroups(int numberOfGroups)
        {
            var groups = new List<Ticket>();
            var groupSize = (int)Math.Ceiling((double)Tickets.Count / numberOfGroups);

            for (int i = 0; i < numberOfGroups; i++)
            {
                groups.AddRange(Tickets.Skip(i * groupSize).Take(groupSize));
            }

            return groups;
        }

        public IEnumerable<Ticket> GetPassangersForSecurityCheck()
        {
            var passangersForSecurityCheck = new List<Ticket>();
            var ticketsInRandomOrder = Tickets.OrderBy(a => Guid.NewGuid()).ToList();

            for (int i = 0; i < ticketsInRandomOrder.Count; i += 5)
            {
                passangersForSecurityCheck.Add(ticketsInRandomOrder[i]);
            }

            return passangersForSecurityCheck;
        }
    }
}
