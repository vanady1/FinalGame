using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    private Transform _target;
    private Vector2 _targetDirection;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target.transform;
    }

    private void Update()
    {
        GetTargetDirection();
        FlipSprite();
    }

    private void GetTargetDirection()
    {
        _targetDirection = _target.position - transform.position;
    }

    private void FlipSprite()
    {
        if (_targetDirection.x > 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
