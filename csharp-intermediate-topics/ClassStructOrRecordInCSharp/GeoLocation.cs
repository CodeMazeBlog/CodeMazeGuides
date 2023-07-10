namespace ClassStructOrRecordInCSharp
{
    public struct GeoLocation
    {
        public string Latitude;
        public string Longitude;

        public override string ToString() => $"(lat: {Latitude}, lon:{Longitude})";
    }
}
