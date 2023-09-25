using System.Diagnostics;

namespace PeriodicTimerCSharp
{
    public class PeriodicTimerMethods
    {
        public static PeriodicTimer CreateRandomArray(int size)
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
            
            var array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = Random.Shared.Next();

            return timer;
        }
    }
}
