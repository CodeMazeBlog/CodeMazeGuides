namespace IntroductionToWolverineLibrary.Models;

public record NewBookOrder(Guid OrderId, string CustomerName, int BookId);

public record BookReview(int BookId, string ReviewerName, int Rating);