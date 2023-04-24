using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInRangeTransition : Transition
{
    [SerializeField] private float _transitionInRange;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (Target == null)
            return;

        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionInRange)
        {
            NeedTransit = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _transitionInRange);
    }
}
