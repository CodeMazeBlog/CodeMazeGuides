namespace JsonObjectsWithHttpClient
{
    public interface IPetService
	{
        Task<PetDto> PostAsStringContent();

        Task<PetDto> PostAsJson();
    }
}