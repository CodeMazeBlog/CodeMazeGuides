namespace GetListOfProperties.Entity
{
    public sealed class User : Person
    {
        public string? Email { get; set; }
        private string? Password { get; set; }
    }
}
