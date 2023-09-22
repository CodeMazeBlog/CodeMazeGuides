namespace BlazorWebAssemblyAppForAheadOfTimeCompilation
{
    public interface IPrimeNumberService
    {
        Task<List<int>> GetPrimeNumbersAsync();
    }
}