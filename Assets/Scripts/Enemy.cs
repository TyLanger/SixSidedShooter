using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event System.Action OnDeath;

    Health health;
    Motor motor;

    public Transform playerTrans;

    public int number = 1;
    public float moveSpeed = 6;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnDeath += Death;

        motor = GetComponent<Motor>();
        motor.ChangeMoveSpeed(moveSpeed);
    }

    private void Update()
    {
        motor.MoveTowards(playerTrans.position - transform.position);
    }

    public void Setup(Transform player, int enemyNumber)
    {
        number = enemyNumber;
        playerTrans = player;
        health.maxHealth = number;

    }

    void Death()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
