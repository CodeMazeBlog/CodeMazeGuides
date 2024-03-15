// Middle man example
var ticketsProvider = new RefactoringCouplers.MiddleMan.TicketsProvider();
var ticket = ticketsProvider.GetConcertTicket("Band", DateTime.Today);

// Message chain example
new RefactoringCouplers.MessageChain.Incorrect.TicketGenerator()
    .ReserveSeat()
    .ProcessPayment()
    .SendEmailConfirmation()
    .GeneratePDFTicket();

new RefactoringCouplers.MessageChain.Correct.TicketGenerator().GenerateTicket();
