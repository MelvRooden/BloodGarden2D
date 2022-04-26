public interface IUnit
{
    int GetHealth { get; }

    public void TakeDamage(int damage);
}
