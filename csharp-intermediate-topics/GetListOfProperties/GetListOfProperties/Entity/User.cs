namespace GetListOfProperties.Entity
{
    public sealed class User : Person
    {
        public string? Email { get; set; } = default!;
        private string? Password { get; set; } = default!;
    }
}
