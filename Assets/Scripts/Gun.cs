using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Projectile projectile;
    public float projectileMoveSpeed = 20;
    protected int damageBoost = 0;

    public Transform muzzlePoint;

    public float timeBetweenShots = 0.1f;
    public float reloadTime = 1;
    public int maxAmmo = 6;
    protected int currentShots = 0;
    int boostAmmo = 0;

    protected float timeOfNextShot = 0;

    private void Awake()
    {
        InstantReload();
    }

    protected IEnumerator StartReload()
    {
        yield return new WaitForSeconds(reloadTime);
        InstantReload();
    }

    void InstantReload()
    {
        currentShots = maxAmmo + boostAmmo;
    }

    protected bool CanFire()
    {
        bool hasBullets = (currentShots > 0);
        bool fireRateCheck = (timeOfNextShot < Time.time);
        return hasBullets && fireRateCheck;
    }

    public virtual void Fire()
    {
        if (CanFire())
        {
            Projectile copy = Instantiate(projectile, muzzlePoint.position, transform.rotation);
            copy.Setup(projectileMoveSpeed, damageBoost);

            currentShots--;
            timeOfNextShot = Time.time + timeBetweenShots;
            if(currentShots <= 0)
            {
                StartCoroutine(StartReload());
            }
        }
    }

    public void BuffDamage(int boost)
    {
        damageBoost = boost;
    }

    public void ClipExtend(int boost)
    {
        boostAmmo = boost;
    }
}
