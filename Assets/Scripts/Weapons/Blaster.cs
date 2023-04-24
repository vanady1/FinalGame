using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    public override void Shoot()
    {
        Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
    }
}
