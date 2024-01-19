using Business.Models;

namespace Data;

public class MusicRepository
{
    private readonly IEnumerable<Artist> _artists = new[]
    {
        new Artist(1, "The Black Keys", ["Rock", "Blues", "Alternative"], [new Album(1, "The Big Come Up", 2002), new Album(2, "Thickfreakness", 2003)]),
        new Artist(2, "Eric Prydz", ["Dance", "Electronic"], [new Album(3, "Pryda", 2012), new Album(4, "Opus", 2016)]),
        new Artist(3, "Sam Cooke", ["Soul", "Gospel"], [new Album(5, "Twistin the Night Away", 1962)])
    };

    private readonly IEnumerable<Concert> _concerts = new[]
    {
        new Concert(1, "United States", new DateOnly(2024, 6, 1)),
        new Concert(2, "Australia", new DateOnly(2024, 5, 1))
    };

    public Artist? GetArtistById(int id) => _artists.SingleOrDefault(artist => artist.Id == id);

    public IEnumerable<Artist> GetAllArtists() => _artists;

    public IEnumerable<Concert> GetAllConcerts() => _concerts;
}
