using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Projectile
{

    public Projectile explosion;
    public float timeToExplode = 1;
    public float maxRadius = 4;

    IEnumerator ExplodeProjectile()
    {
        var copy = Instantiate(explosion, transform.position, Quaternion.identity);
        copy.Setup(0, damageBoost);
        float ogExplodeTime = timeToExplode;

        while(timeToExplode > 0)
        {
            timeToExplode -= Time.deltaTime;

            copy.transform.localScale = Vector3.one * Mathf.Lerp(1, maxRadius, (ogExplodeTime - timeToExplode)/ogExplodeTime);

            yield return null;
        }

        yield return null;
        copy.Death();
        Death();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        // stop moving
        Setup(0, damageBoost);
        GetComponent<SphereCollider>().enabled = false;
        StartCoroutine(ExplodeProjectile());
    }
}
