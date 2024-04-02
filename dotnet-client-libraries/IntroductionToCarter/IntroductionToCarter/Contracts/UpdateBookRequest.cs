namespace IntroductionToCarter.Contracts;

public record UpdateBookRequest(
    string Title,
    string Author,
    string ISBN,
    int Year);
