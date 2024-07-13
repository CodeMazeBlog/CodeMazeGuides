using IntroductionToWolverineLibrary.Models;

namespace IntroductionToWolverineLibrary.Handlers;

public class OrderHandler
{
    public static void Handle(NewBookOrder order)
    {
        Console.WriteLine($"New order received: {order}");
    }
}

public class OrderReplyHandler
{
    public static string Handle(NewBookOrder order) => $"New order received: {order}";
}

public class BookReviewHandler
{
    public static string Handle(BookReview review) => $"New book review received: {review}";
}