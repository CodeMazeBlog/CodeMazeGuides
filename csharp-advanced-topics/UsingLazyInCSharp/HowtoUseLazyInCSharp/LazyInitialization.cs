
using Microsoft.Data.SqlClient;

namespace HowtoUseLazyInCSharp
{
    public class LazyInitialization
    {
        public object RunLazyObjectExample()
        {
            var lazyObject = new Lazy<object>();
            var value = lazyObject.Value;

            return value;
        }

        public ExpensiveObject RunLazyExpensiveObjectExample()
        {
            var lazyExpensiveObject = new Lazy<ExpensiveObject>();

            return lazyExpensiveObject.Value;
        }

        public ExpensiveObject RunLazyObjectWithValueExample()
        {
            var lazyExpensiveObject = new Lazy<ExpensiveObject>(() => new ExpensiveObject());

            return lazyExpensiveObject.Value;
        }

        public object RunLazyObjectWithExceptionHandlingExample()
        {
            try
            {
                var lazyObject = new Lazy<object>(() =>
                {
                    // Throw an exception inside the factory method
                    throw new InvalidOperationException("Exception in factory method");
                });

                var value = lazyObject.Value;

                return value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occurred: {ex.Message}");
            }
        }

        public void RunInitialOverheadExample()
        {
            // Creating a Lazy<T> instance incurs an initial overhead
            Lazy<ExpensiveObject> lazyObject = new Lazy<ExpensiveObject>();

            // Accessing the Value property initializes the object (if not already initialized)
            ExpensiveObject obj = lazyObject.Value;

            // Use the initialized object         
        }
        public void RunMemoryConsumptionExample()
        {
            // Deferring initialization of an expensive object
            Lazy<ExpensiveObject> lazyObject = new Lazy<ExpensiveObject>();

            // Other code...

            // Only when needed, the object is created and consumes memory
            ExpensiveObject obj = lazyObject.Value;

            // Use the initialized object

        }
        public void RunThreadSynchronizationOverheadExample()
        {
            // Using Lazy<T> with thread-safe mode
            Lazy<ExpensiveObject> lazyObject = new Lazy<ExpensiveObject>(LazyThreadSafetyMode.ExecutionAndPublication);

            // Multiple threads accessing the Value property simultaneously
            Parallel.For(0, 10, _ =>
            {
                ExpensiveObject obj = lazyObject.Value;

                // Use the initialized object within the parallel loop
                // ...
            });

            // Use the initialized object outside the parallel loop
            // ...
        }
        public ExpensiveObject RunLazyInitializationExample()
        {
            Lazy<ExpensiveObject> lazyObject = new Lazy<ExpensiveObject>(() =>
            {
                // Create and initialize the expensive object
                return new ExpensiveObject();
            });

            return lazyObject.Value;
        }

        public Configuration RunLazyConfigurationExample()
        {

            Lazy<Configuration> lazyConfig = new Lazy<Configuration>(() =>
            {
                string key = "";
                var config = new Configuration();
                config.LoadConfigurationFromFile(key);
                return config;
            });

            return lazyConfig.Value;
        }
        public void RunEagerInitializationExample()
        {
            Logger logger = new();
            logger.Log("Initializing the application");

            // Use the logger object immediately
            // ...
        }
        public Cache RunLazyCacheExample()
        {
            Lazy<Cache> lazyCache = new Lazy<Cache>(LazyThreadSafetyMode.ExecutionAndPublication);

            // Other code...

            return lazyCache.Value;
        }

    }
}
