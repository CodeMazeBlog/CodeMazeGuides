namespace ClassStructOrRecordInCSharp
{
    public struct GeoLocation
    {
        private string _latitude;
        private string _longitude;

        public override string ToString() => $"(lat: {_latitude}, lon:{_longitude})";
    }
}
