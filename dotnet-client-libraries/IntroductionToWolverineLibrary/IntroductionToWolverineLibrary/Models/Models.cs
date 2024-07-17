namespace IntroductionToWolverineLibrary.Models;

public record Order(Guid OrderId, string CustomerName, int BookId);

public record BookReview(int BookId, string ReviewerName, int Rating);