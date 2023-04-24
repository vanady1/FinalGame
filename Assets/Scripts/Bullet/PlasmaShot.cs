using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaShot : Bullet
{
    [SerializeField] private GameObject _effectTemplate;
    [SerializeField] private float _effectLifeTime;

    protected override void Die()
    {
        GameObject effect  = Instantiate(_effectTemplate, transform.position, transform.rotation);
        Destroy(effect, _effectLifeTime);
        Destroy(gameObject);
    }
}
