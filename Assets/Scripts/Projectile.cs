using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody rb;
    float currentSpeed = 0;
    public float lifetime = 5;
    public int damage = 1;
    public int damageBoost = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Setup(float speed, int boost)
    {
        currentSpeed = speed;
        damageBoost = boost;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (transform.forward * currentSpeed * Time.fixedDeltaTime));
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            Death();
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Health h = other.GetComponent<Health>();
        if(h)
        {
            h.TakeDamage(damage + damageBoost);
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
