namespace JsonObjectsWithHttpClient;

public interface IPetService
{
    Task<PetDto?> PostAsStringContentAsync();

    Task<PetDto?> PostAsJsonAsync();
}