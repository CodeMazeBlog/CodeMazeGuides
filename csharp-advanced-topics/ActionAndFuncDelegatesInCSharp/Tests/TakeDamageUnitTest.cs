namespace Tests;

public class TakeDamageUnitTest : IDisposable
{
    private readonly StringWriter _sw = new();

    public void Dispose()
    {
        _sw.Dispose();
    }

    [Theory]
    [InlineData(100, 1, 99)]
    [InlineData(10, 4, 6)]
    [InlineData(40, 5, 35)]
    [InlineData(70, 3, 67)]
    public void GivenStartingHealthX_WhenDamagedByYThatIsLessThanX_ThenHealthBecomesZAndOnDieIsNotCalled(int startingHealth, int damage, int remainingHealth)
    {
        Action writeWhenDead = () => _sw.Write("Dead!");
        Enemy enemy = new(startingHealth, writeWhenDead);

        enemy.TakeDamage(damage);

        enemy.Health.ShouldBe(remainingHealth);
    }

    [Theory]
    [InlineData(100, 1, 99)]
    [InlineData(10, 4, 6)]
    [InlineData(40, 5, 35)]
    [InlineData(70, 3, 67)]
    public void GivenStartingHealthX_WhenDamagedByYT_ThenHealthBecomesZ(int startingHealth, int damage, int remainingHealth)
    {
        Enemy enemy = new(startingHealth, null);

        enemy.TakeDamage(damage);

        enemy.Health.ShouldBe(remainingHealth);
    }

    [Theory]
    [InlineData(100, 1)]
    [InlineData(10, 4)]
    [InlineData(40, 5)]
    [InlineData(70, 3)]
    public void GivenStartingHealthX_WhenDamagedByYThatIsLessThanX_OnDieIsNotCalled(int startingHealth, int damage)
    {
        Action writeWhenDead = () => _sw.Write("Dead!");
        Enemy enemy = new(startingHealth, writeWhenDead);

        enemy.TakeDamage(damage);

        _sw.ToString().ShouldBeEmpty();
    }

    [Theory]
    [InlineData(100, 100)]
    [InlineData(10, 40)]
    [InlineData(40, 50)]
    [InlineData(70, 345)]
    public void GivenStartingHealthX_WhenDamagedByYThatIsMoreThanOrEqualToX_OnDieIsCalled(int startingHealth, int damage)
    {
        Action writeWhenDead = () => _sw.Write("Dead!");
        Enemy enemy = new(startingHealth, writeWhenDead);

        enemy.TakeDamage(damage);

        _sw.ToString().ShouldBe("Dead!");
    }
}