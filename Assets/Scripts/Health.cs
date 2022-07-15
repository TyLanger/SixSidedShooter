using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 10;
    [SerializeField] int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
