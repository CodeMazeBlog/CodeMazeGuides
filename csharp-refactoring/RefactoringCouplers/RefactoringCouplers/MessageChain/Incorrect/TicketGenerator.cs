namespace RefactoringCouplers.MessageChain.Incorrect;

public class TicketGenerator
{
    public TicketGenerator ReserveSeat()
    {
        // Seat reservation logic here
        return this;
    }

    public TicketGenerator ProcessPayment()
    {
        // Process payment logic here
        return this;
    }

    public TicketGenerator SendEmailConfirmation()
    {
        // Send email confirmation logic here
        return this;
    }

    public TicketGenerator GeneratePDFTicket()
    {
        // Generate PDF ticket logic here
        return this;
    }
}