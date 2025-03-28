using Patterns.Calculators;
using UnityEngine;

public class Injector : MonoBehaviour
{
    [SerializeField] private IDependencyInjectable<IDamadgebale> _target; 

    private void Awake()
    {
        if (_target == null)
        {
            _target = FindObjectOfType<PlayerAttack>() as IDependencyInjectable<IDamadgebale>;
        }
    }

    public void Init()
    {
        if (_target == null)
        {
            return;
        }

        CalculatorType calculatorType = SelectCalculatorType();

        IDamadgebale damageable = CreateDamageable(calculatorType);

        _target.Inject(damageable);
    }

    private CalculatorType SelectCalculatorType()
    {
        float randomValue = Random.value; 

        if (randomValue < 0.7f)
        {
            return CalculatorType.Range;
        }
        else
        {
            return CalculatorType.Crit;
        }
    }

    private IDamadgebale CreateDamageable(CalculatorType calculatorType)
    {
        return calculatorType switch
        {
            CalculatorType.Range => new DamageCalculatorRange(),
            CalculatorType.Crit => new DamageCalculatorCrit(),
            _ => throw new System.ArgumentException("Unknown calculator type")
        };
    }
}