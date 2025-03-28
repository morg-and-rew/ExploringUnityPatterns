using UnityEngine;

public class PlayerAttack : MonoBehaviour, IDependencyInjectable<IDamadgebale>
{
    private IDamadgebale _damageable;

    public void Inject(IDamadgebale damageable)
    {
        _damageable = damageable;
    }

    // Метод атаки
    public void Attack(Enemy enemy)
    {
        if (_damageable == null)
        {
            Debug.LogError("Damageable dependency is not injected.");
            return;
        }

        float damage = _damageable.CalculateDamage();
        enemy.TakeDamage(damage);
    }
}