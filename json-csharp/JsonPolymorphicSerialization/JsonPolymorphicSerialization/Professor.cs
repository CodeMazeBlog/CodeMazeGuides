namespace JsonPolymorphicSerialization
{
    public class Professor : Member
    {
        public string? Rank { get; set; }

        public bool IsTenured { get; set; }
    }
}
