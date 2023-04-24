using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public event UnityAction PlayerDied;
    public event UnityAction<int> HealthChanged;

    protected override void Start()
    {
        base.Start();
        HealthChanged.Invoke(_currentHealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        HealthChanged.Invoke(_currentHealth);
    }

    protected override void Die()
    {
        PlayerDied.Invoke();
        gameObject.SetActive(false);
    }
}
