namespace BlazorWebAssemblyAppForAOT
{
    public class PrimeNumberService : IPrimeNumberService
    {
        public async Task<List<int>> GetPrimeNumbersAsync()
        {
            return await Task.Run(() =>
            {
                var primes = new List<int>();
                var isPrime = new bool[1000000 + 1];

                for (int i = 2; i <= 1000000; i++)
                {
                    isPrime[i] = true;
                }

                for (int p = 2; p * p <= 1000000; p++)
                {
                    if (isPrime[p])
                    {
                        for (int i = p * p; i <= 1000000; i += p)
                        {
                            isPrime[i] = false;
                        }
                    }
                }

                for (int i = 2; i <= 1000000; i++)
                {
                    if (isPrime[i])
                    {
                        primes.Add(i);
                    }
                }

                return primes;
            });
        }
    }
}