namespace BlazorWebAssemblyAppForAOT
{
    public interface IPrimeNumberService
    {
        Task<List<int>> GetPrimeNumbersAsync();
    }
}
