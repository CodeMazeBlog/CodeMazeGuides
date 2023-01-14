namespace GetListOfProperties.Entity
{
    public class Configuration
    {
        public static string StaticProperty { get; set; } = default!;
        public string NonStaticProperty { get; set; } = default!;
    }
}
