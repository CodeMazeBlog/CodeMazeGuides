namespace RefactoringCouplers.MiddleMan;

public class TicketGenerator
{
    public Ticket GenerateConcertTicket(string band, DateTime date)
    {
        return new Ticket(band, date);
    }
}