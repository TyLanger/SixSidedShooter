using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : Projectile
{
    protected override void OnTriggerEnter(Collider other)
    {

        Health h = other.GetComponent<Health>();
        if (h)
        {
            h.TakeDamage(damage + damageBoost);
        }
    }
}
