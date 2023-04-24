using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterV3 : Weapon
{
    [SerializeField] private float _bulletSpread;

    public override void Shoot()
    {
        Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation * new Quaternion(_bulletSpread, 1, 0, 0));
        Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation * new Quaternion(-_bulletSpread, 1, 0, 0));
    }
}
