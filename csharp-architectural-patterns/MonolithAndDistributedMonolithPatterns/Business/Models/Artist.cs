namespace Business.Models;

public record Artist(int Id, string Name, string[] Genres, Album[] Albums);
