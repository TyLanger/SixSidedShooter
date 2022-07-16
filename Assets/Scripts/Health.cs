using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event System.Action OnDeath;

    public int maxHealth = 10;
    [SerializeField] int currentHealth;

    bool isInvuln = false;

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
        if (isInvuln)
            return;
        currentHealth -= damage;
        if (currentHealth <= 0)
            Death();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void SetInvincible(bool value)
    {
        isInvuln = value;
    }

    void Death()
    {
        OnDeath?.Invoke();
    }
}
