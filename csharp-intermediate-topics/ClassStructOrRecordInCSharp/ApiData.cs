namespace ClassStructOrRecordInCSharp
{
    public record ApiData
    {
        public int Id { get; set; }
    }

    public record OtherApiData(string Id);
}
