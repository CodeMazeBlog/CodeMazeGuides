using ActionAndFuncDelegatesInCsharp;

//Main program execution

static void WriteCurrentDateTime() => Console.WriteLine(DateTime.Now);

static string GetGreetingsMessage(string name, int age) 
{
    return $"Hello, my name is {name} and I'm {age} years old!";
}

Action writeCurrentDateTimeDelegate = WriteCurrentDateTime;
writeCurrentDateTimeDelegate.Invoke();

Func<string, int, string> getGreetingsMessageDelegate = GetGreetingsMessage;
var greetingsMessage = getGreetingsMessageDelegate("John", 26);
Console.WriteLine(greetingsMessage);

List<Ticket> ticketList = new List<Ticket>
{
    new Ticket(50),
    new Ticket(50),
    new Ticket(35)
};

var movieOrder = new MovieOrder(ticketList, "The Godfather");

static double CalculateOrderPrice(List<Ticket> tickets, bool isDiscountAplied)
{
    var totalPrice = tickets.Sum(ticket => ticket.Price);

    if (isDiscountAplied)
    {
        return totalPrice * 0.75;
    }

    return totalPrice;
}

static void WriteToConsole(string message)
{
    Console.WriteLine(message);
}

var calculatedPrice = movieOrder.CalculateTotalPrice(CalculateOrderPrice, true);

Console.WriteLine($"Total price for the order is {calculatedPrice}");

movieOrder.Pay(WriteToConsole);

//Helpers

public class MovieOrder
{
    private string _title;
    private List<Ticket> _tickets;

    public MovieOrder(List<Ticket> tickets, string title)
    {
        _tickets = tickets;
        _title = title;
    }

    public void Pay(Action<string> notifyUser)
    {
        notifyUser($"You have bought {_tickets.Count} ticket(s) for '{_title}' movie!");
    }

    public double CalculateTotalPrice(Func<List<Ticket>, bool, double> priceCalculator, bool isDiscountApplied)
    {
        return priceCalculator.Invoke(_tickets, isDiscountApplied);
    }
}
