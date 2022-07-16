using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonProjectile : Projectile
{

    public int numPierces = 100;

    protected override void OnTriggerEnter(Collider other)
    {
        //base.OnTriggerEnter(other);
        Health h = other.GetComponent<Health>();
        if(h)
        {
            h.TakeDamage(damage + damageBoost);
            numPierces--;
            if(numPierces <= 0)
            {
                Death();
            }
        }
    }
}
