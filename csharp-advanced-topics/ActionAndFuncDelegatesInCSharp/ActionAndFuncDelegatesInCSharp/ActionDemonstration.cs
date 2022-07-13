namespace ActionAndFuncDelegatesInCSharp;

public class Enemy
{
    public int Health { get; private set; }
    private readonly Action _onDie;

    public Enemy(int startingHealth, Action onDie)
    {
        Health = startingHealth;
        _onDie = onDie;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0) _onDie?.Invoke();
    }
}
