namespace EqualityOperatorVsEqualsMethodInCSharp.Structs
{
    public struct Car
    {
        public string Model { get; set; }
        public int Weight { get; set; }

        public Car(string model, int weight)
        {
            Model = model;
            Weight = weight;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Car other) return false;

            return Model == other.Model && Weight == other.Weight;
        }

        public override int GetHashCode() => (Model, Weight).GetHashCode();

        public static bool operator ==(Car lhs, Car rhs) => lhs.Equals(rhs);

        public static bool operator !=(Car lhs, Car rhs) => !(lhs == rhs);
    }
}