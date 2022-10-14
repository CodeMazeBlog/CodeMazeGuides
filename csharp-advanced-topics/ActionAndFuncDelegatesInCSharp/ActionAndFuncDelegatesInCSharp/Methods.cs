namespace ActionAndFuncDelegatesInCSharp
{
    public static class Methods
    {
        public static double GetProcessResult(double value, Action<double> action, Func<double, double> func)
        {
            action(value);

            return func(value);
        }

    }
}

