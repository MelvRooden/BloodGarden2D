using UnityEngine;

public interface IUnit
{
    int GetHealth { get; }
    Vector3 GetStartingPos { get; }

    public void TakeDamage(int damage);
    public void HealDamage(int damage);
}
