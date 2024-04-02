namespace IntroductionToCarter.Contracts;

public record CreateBookRequest(
    string Title,
    string Author,
    string ISBN,
    int Year);
