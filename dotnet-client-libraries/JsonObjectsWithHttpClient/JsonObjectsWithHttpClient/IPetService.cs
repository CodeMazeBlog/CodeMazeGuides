namespace JsonObjectsWithHttpClient;

public interface IPetService
{
    Task<PetDto?> PostAsStringContentAsync();

    Task<PetDto?> PostWithPostAsJsonAsync();

    Task<PetDto?> PostAsJsonContentAsync();

    Task<PetDto?> PostAsSourceGeneratedJsonAsync();
}