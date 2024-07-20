using IntroductionToWolverineLibrary.Models;

namespace IntroductionToWolverineLibrary.Handlers;

public class OrderHandler
{
    public static void Handle(Order? order) => Console.WriteLine($"New order received: {order}");
}

public class OrderReplyHandler
{
    public static string Handle(Order? order) => $"New order received: {order}";
}

public class BookReviewHandler
{
    public static void Handle(BookReview? review) => Console.WriteLine($"New book review received: {review}");
}