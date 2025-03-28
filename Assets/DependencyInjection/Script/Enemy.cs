using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _helth = 100;

    public void TakeDamage(float damage)
    {
        _helth -= damage;

        Debug.Log(_helth);
    }
}
