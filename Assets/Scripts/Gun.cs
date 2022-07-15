using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Projectile projectile;
    public float projectileMoveSpeed = 20;

    public Transform muzzlePoint;



    public void Fire()
    {
        Projectile copy = Instantiate(projectile, muzzlePoint.position, transform.rotation);
        copy.Setup(projectileMoveSpeed);
    }
}
