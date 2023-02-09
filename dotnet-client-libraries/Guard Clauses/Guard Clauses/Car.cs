namespace Guard_Clauses
{
    public class Car
    {
        public Car(Engine engine)
        {
            if (engine == null)
            {
                throw new ArgumentNullException(nameof(engine), "Engline cannot be null");
            }

            Engine = engine;
        }

        public Engine Engine { get; private set; }
    }
}
