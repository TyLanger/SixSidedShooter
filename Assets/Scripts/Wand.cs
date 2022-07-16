using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Gun
{
    public Orbiter orbiter;


    public override void Fire()
    {
        if(CanFire())
        {
            Projectile copy = Instantiate(projectile, muzzlePoint.position, transform.rotation);
            // first projectile is invisible and has no collider
            copy.Setup(projectileMoveSpeed, damageBoost);

            Orbiter orb = Instantiate(orbiter, muzzlePoint.position, transform.rotation);
            orb.target = copy.transform;
            orb.DamageBoostOrbiters(damageBoost);

            currentShots--;
            timeOfNextShot = Time.time + timeBetweenShots;
            if(currentShots <= 0)
            {
                StartCoroutine(StartReload());
            }
        }
    }
}
