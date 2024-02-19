namespace ActionAndFuncDelegates
{
    public static class AsyncController
    {
        public static async Task<int> DoubleAsync(int number)
        {
            await Task.Delay(1000);

            return number * 2;
        }
    }
}
