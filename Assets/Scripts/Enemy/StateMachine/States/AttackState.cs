using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRange;

    private float _lastAttackTime;
    private PlayerHealth _targetHealth;
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _targetHealth = Target.GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Enemy_Attack");
    }

    private void ApplyDamage()
    {
        if (Vector2.Distance(Target.transform.position, transform.position) <= _attackRange)
        {
            _targetHealth.TakeDamage(_damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
