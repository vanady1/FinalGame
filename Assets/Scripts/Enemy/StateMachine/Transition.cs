using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected virtual void Awake()
    {
        Init(GetComponent<Enemy>().Target);
    }

    protected GameObject Target { get; private set; }

    public State TargetState => _targetState;

    public bool NeedTransit { get;  set; }

    public void Init(GameObject target)
    {
        Target = target;
    }

    public void OnEnable()
    {
        NeedTransit = false;
    }
}
