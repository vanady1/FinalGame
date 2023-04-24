using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOutOfRangeTransition : Transition
{
    [SerializeField] private float _transitionOutOfRange;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (Target == null)
            return;

        if (Vector2.Distance(transform.position, Target.transform.position) > _transitionOutOfRange)
        {
            NeedTransit = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _transitionOutOfRange);
    }
}
