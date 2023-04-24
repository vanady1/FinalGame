using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IdleState : State
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Enemy_Idle");
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
