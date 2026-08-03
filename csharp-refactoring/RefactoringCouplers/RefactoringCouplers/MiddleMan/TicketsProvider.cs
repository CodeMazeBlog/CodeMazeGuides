namespace RefactoringCouplers.MiddleMan;

public class TicketsProvider
{
    private readonly TicketGenerator _ticketGenerator = new();

    public Ticket GetConcertTicket(string band, DateTime date)
    {
        return _ticketGenerator.GenerateConcertTicket(band, date);
    }
}