namespace ClassStructOrRecordInCSharp
{
    public record ApiData
    {
        public int Id { get; init; }
    }

    public record OtherApiData(string Id);
}
