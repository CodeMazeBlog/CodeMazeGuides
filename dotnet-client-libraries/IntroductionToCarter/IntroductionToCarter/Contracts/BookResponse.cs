namespace IntroductionToCarter.Contracts;

public record BookResponse(
    Guid Id,
    string Title,
    string Author,
    string ISBN,
    int Year);
