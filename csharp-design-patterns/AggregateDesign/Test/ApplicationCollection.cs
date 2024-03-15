namespace Test;

[CollectionDefinition("Application collection")]
public class ApplicationCollection : ICollectionFixture<ApplicationFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}