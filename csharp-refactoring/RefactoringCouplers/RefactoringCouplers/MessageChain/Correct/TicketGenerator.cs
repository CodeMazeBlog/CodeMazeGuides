namespace RefactoringCouplers.MessageChain.Correct;

public class TicketGenerator
{
    public void GenerateTicket() =>
        ReserveSeat().ProcessPayment().SendEmailConfirmation().GeneratePDFTicket();

    private TicketGenerator ReserveSeat()
    {
        // Seat reservation logic here
        return this;
    }

    private TicketGenerator ProcessPayment()
    {
        // Process payment logic here
        return this;
    }

    private TicketGenerator SendEmailConfirmation()
    {
        // Send email confirmation logic here
        return this;
    }

    private TicketGenerator GeneratePDFTicket()
    {
        // Generate PDF ticket logic here
        return this;
    }
}
