﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachine))] 
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected GameObject Target { get; set; }

    protected virtual void Awake()
    {
        Target = GetComponent<Enemy>().Target;
    }

    public void Enter(GameObject target)
    {
        if(enabled == false)
        {
            Target = target;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }
}
