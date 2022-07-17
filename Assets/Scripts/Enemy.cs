using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event System.Action OnDeath;

    protected Health health;
    protected Motor motor;

    public Transform playerTrans;

    public int number = 1;
    public float moveSpeed = 6;

    public Sprite[] faceSprites;
    public SpriteRenderer[] spriteRenderers;

    public GameObject pickup;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnDeath += Death;

        motor = GetComponent<Motor>();
        motor.ChangeMoveSpeed(moveSpeed);
    }

    protected virtual void Update()
    {
        motor.MoveTowards(playerTrans.position - transform.position);
    }

    public void Setup(Transform player, int enemyNumber)
    {
        number = enemyNumber;
        playerTrans = player;
        health.maxHealth = number;

        foreach (var renderer in spriteRenderers)
        {
            renderer.sprite = faceSprites[number - 1];

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player p = collision.transform.GetComponent<Player>();
        if (p != null)
        {
            p.GetComponent<Health>().TakeDamage(number);
            Death();
        }
    }

    protected virtual void Death()
    {
        if(Random.Range(1,7) == 1)
        {
            if (pickup != null)
            {
                Instantiate(pickup, transform.position, Quaternion.identity);
            }
        }
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
