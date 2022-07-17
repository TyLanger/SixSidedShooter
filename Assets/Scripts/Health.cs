using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public event System.Action OnDeath;

    public int maxHealth = 10;
    [SerializeField] int currentHealth;

    bool isInvuln = false;

    public bool isPlayer = false;
    public Sprite[] diceFaces;
    public Image[] healthDice;

    public GameObject damageText;

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

        if(damageText)
        {
            var copy = Instantiate(damageText, transform.position + Vector3.up, Quaternion.identity);
            copy.GetComponentInChildren<DamageText>().SetText(damage);
        }

        if (isPlayer)
        {
            UpdatePlayerHealth();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (isPlayer)
        {
            UpdatePlayerHealth();
        }
    }

    void UpdatePlayerHealth()
    {
        if(currentHealth > 6)
        {
            int secondDie = currentHealth - 6;
            healthDice[1].enabled = true;
            healthDice[1].sprite = diceFaces[secondDie - 1];
            healthDice[0].sprite = diceFaces[5];
        }
        else if(currentHealth > 0)
        {
            healthDice[1].enabled = false;
            healthDice[0].sprite = diceFaces[currentHealth - 1];
        }
        else
        {
            healthDice[1].enabled = false;
            healthDice[0].enabled = false;
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
