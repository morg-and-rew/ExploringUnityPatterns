using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Injector _injector;
    [SerializeField] private PlayerAttack _playerAttack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _injector.Init();
            _playerAttack.Attack(enemy);
        }
    }
}