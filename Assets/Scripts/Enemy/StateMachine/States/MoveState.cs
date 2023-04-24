using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _moveSpeed;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector2 _targetDirection;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>(); ;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Enemy_Walk");
    }

    private void OnDisable()
    {
        _rigidbody.velocity = new Vector2(0, 0);
    }

    private void Update()
    {
        if (Target == null)
            return;

        GetDirectionToTarget();
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        _rigidbody.velocity = Vector2.ClampMagnitude(_targetDirection * _moveSpeed, _moveSpeed);
    }

    private void GetDirectionToTarget()
    {
        _targetDirection = Target.transform.position - transform.position;
    }
}
