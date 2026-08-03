namespace ExpandingLIQNwithMoreLINQ
{
    public class Ticket
    {
        public int? TicketNumber { get; set; }
        public int? SeatNumber { get; set; }
        public string? PassengerName { get; set; }
        public string? TicketClass { get; set; }
        public decimal? Price { get; set; }

        public Ticket()
        {
        }

        public Ticket(
            int ticketNumber,
            int seatNumber,
            string passengerName,
            string ticketClass,
            decimal price)
        {
            TicketNumber = ticketNumber;
            SeatNumber = seatNumber;
            PassengerName = passengerName;
            TicketClass = ticketClass;
            Price = price;
        }
    }
}
