using Ardalis.GuardClauses;

namespace Guard_Clauses
{
    public class Car
    {
        public Car(Engine engine)
        {
            Engine = Guard.Against.Null(engine, nameof(engine), "Engine cannot be null!");
        }

        public Engine Engine { get; private set; }
    }
}
