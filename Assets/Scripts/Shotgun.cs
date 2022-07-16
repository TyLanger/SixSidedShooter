using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public int numShots = 2;
    public float spreadAngle = 30;


    public override void Fire()
    {
        if(CanFire())
        {
            if (numShots > 1)
            {
                for (int i = 0; i < numShots; i++)
                {
                    Projectile copy = Instantiate(projectile, muzzlePoint.position, transform.rotation);
                    float angle = 2 * spreadAngle / (numShots - 1);
                    copy.transform.Rotate(Vector3.up, -spreadAngle + angle * i);
                    copy.Setup(projectileMoveSpeed, damageBoost);

                }
                // currentShots is your actual ammo
                /*
                currentShots -= numShots;
                timeOfNextShot = Time.time + timeBetweenShots;
                if (currentShots < numShots)
                {
                    StartCoroutine(StartReload());
                }
                */

                // currentShots is how many times you can shoot without reloading
                // regardless of numShots (i.e. shoot 2 at a time vs shoot 12 at a time)
                currentShots--;
                timeOfNextShot = Time.time + timeBetweenShots;
                if(currentShots <= 0)
                {
                    StartCoroutine(StartReload());
                }
            }
        }
    }
}
