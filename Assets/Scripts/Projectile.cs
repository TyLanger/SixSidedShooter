using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody rb;
    float currentSpeed = 0;
    float lifetime = 5;
    public int damage = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Setup(float speed)
    {
        currentSpeed = speed;
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

    private void OnTriggerEnter(Collider other)
    {
        Health h = other.GetComponent<Health>();
        if(h)
        {
            h.TakeDamage(damage);
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
