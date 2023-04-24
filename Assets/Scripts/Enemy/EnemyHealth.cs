using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private int _reward;

    public event UnityAction<Enemy> EnemyDied; 

    protected override void Die()
    {
        if (transform.localScale.x > 0)
        {
            Instantiate(_deathEffect, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(_deathEffect, transform.position, new Quaternion(0f, 180f, 0f, 1));
        }

        EnemyDied.Invoke(GetComponent<Enemy>());
        GetComponent<Enemy>().Target.GetComponent<PlayerMoney>().AddMoney(_reward);
        gameObject.SetActive(false);
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }
}

